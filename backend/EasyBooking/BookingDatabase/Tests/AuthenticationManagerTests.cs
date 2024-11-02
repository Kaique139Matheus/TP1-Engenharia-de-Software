using BookingDatabase.Data;
using BookingDatabase.Models;
using BookingDatabase.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookingDatabase.Tests
{
	[Collection("Database collection")]
	public class AuthenticationManagerTests
	{
		private readonly EasyBookingContext context;

		private readonly ClientModel testClient = new ClientModel
		{
			Email = "test@example.com",
			Password = "password",
			CPF = "12345678900",
			FirstName = "John",
			LastName = "Doe"
		};

		private readonly ProviderModel testProvider = new ProviderModel
		{
			Email = "test@example.com",
			Password = "password",
			Name = "Test Provider",
			CNPJ = "12345678901234"
		};

		public AuthenticationManagerTests()
		{
			EasyBookingContext.TestDatabase = true;
			context = new EasyBookingContext();

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			AuthenticationManager.Instance.Logout();
		}

		[Fact]
		public void Login_ShouldLoginClient()
		{
			// Arrange
			context.Clients.Add(testClient);
			context.SaveChanges();

			// Act
			AuthenticationManager.Instance.Login(context, testClient.Email, testClient.Password);

			// Assert
			Assert.True(AuthenticationManager.Instance.IsUserLoggedIn(testClient.ID));
		}

		[Fact]
		public void Login_ShouldLoginProvider()
		{
			// Arrange
			context.Providers.Add(testProvider);
			context.SaveChanges();

			// Act
			AuthenticationManager.Instance.Login(context, testProvider.Email, testProvider.Password);

			// Assert
			Assert.True(AuthenticationManager.Instance.IsUserLoggedIn(testProvider.ID));
		}

		[Fact]
		public void Login_ShouldThrowException_WhenEmailNotFound()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => AuthenticationManager.Instance.Login(context, testClient.Email, testClient.Password));
		}

		[Fact]
		public void Login_ShouldThrowException_WhenIncorrectPassword()
		{
			// Arrange
			context.Clients.Add(testClient);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<Exception>(() => AuthenticationManager.Instance.Login(context, testClient.Email, "wrongpassword"));
		}

		[Fact]
		public void Logout_ShouldLogout()
		{
			// Arrange
			context.Clients.Add(testClient);
			context.SaveChanges();
			AuthenticationManager.Instance.Login(context, testClient.Email, testClient.Password);

			// Act
			AuthenticationManager.Instance.Logout();

			// Assert
			Assert.False(AuthenticationManager.Instance.IsUserLoggedIn(testClient.ID));
		}

		[Fact]
		public void CreateClient_ShouldLogInClient()
		{
			Assert.True(context.Clients.Count() == 0);

			// Act
			AuthenticationManager.Instance.CreateClientAccount(context, testClient.Email, testClient.Password, testClient.CPF, testClient.FirstName, testClient.LastName);

			// Assert
			Assert.True(AuthenticationManager.Instance.IsLoggedIn);
		}

		[Fact]
		public void CreateClient_ShouldThrowException_WhenEmailInUse()
		{
			// Arrange
			context.Providers.Add(testProvider);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<Exception>(() => AuthenticationManager.Instance.CreateClientAccount(context, testClient.Email, testClient.Password, testClient.CPF, testClient.FirstName, testClient.LastName));
		}

		[Fact]
		public void AddClient_ShouldThrowException_WhenCPFIsInUse()
		{
			// Arrange
			var client = new ClientModel
			{
				Email = "test2@example.com",
				Password = "password",
				CPF = testClient.CPF,
				FirstName = "Jane",
				LastName = "Doe"
			};
			context.Clients.Add(client);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<DbUpdateException>(() => AuthenticationManager.Instance.CreateClientAccount(context, testClient.Email, testClient.Password, testClient.CPF, testClient.FirstName, testClient.LastName));
		}

		[Fact]
		public void CreateProvider_ShouldLogInProvider()
		{
			// Act
			AuthenticationManager.Instance.CreateProviderAccount(context, testProvider.Email, testProvider.Password, testProvider.Name, testProvider.CNPJ);

			// Assert
			Assert.True(AuthenticationManager.Instance.IsLoggedIn);
		}

		[Fact]
		public void CreateProvider_ShouldThrowException_WhenEmailInUse()
		{
			// Arrange
			context.Clients.Add(testClient);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<Exception>(() => AuthenticationManager.Instance.CreateProviderAccount(context, testProvider.Email, testProvider.Password, testProvider.Name, testProvider.CNPJ));
		}
	}
}
