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
			var testClient = TestObjects.TestClient;
			context.Clients.Add(testClient);
			context.SaveChanges();

			// Act
			AuthenticationManager.Instance.Login(context, testClient.Email, testClient.Password, out var isProvider);

			// Assert
			Assert.False(isProvider);
			Assert.True(AuthenticationManager.Instance.IsUserLoggedIn(testClient.ID));
		}

		[Fact]
		public void Login_ShouldLoginProvider()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			context.Providers.Add(testProvider);
			context.SaveChanges();

			// Act
			AuthenticationManager.Instance.Login(context, testProvider.Email, testProvider.Password, out var isProvider);

			// Assert
			Assert.True(isProvider);
			Assert.True(AuthenticationManager.Instance.IsUserLoggedIn(testProvider.ID));
		}

		[Fact]
		public void Login_ShouldThrowException_WhenEmailNotFound()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => AuthenticationManager.Instance.Login(context, "email", "password", out var _));
		}

		[Fact]
		public void Login_ShouldThrowException_WhenIncorrectPassword()
		{
			// Arrange
			var testClient = TestObjects.TestClient;
			context.Clients.Add(testClient);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<Exception>(() => AuthenticationManager.Instance.Login(context, testClient.Email, "wrongpassword", out var _));
		}

		[Fact]
		public void Logout_ShouldLogout()
		{
			// Arrange
			var testClient = TestObjects.TestClient;
			context.Clients.Add(testClient);
			context.SaveChanges();
			AuthenticationManager.Instance.Login(context, testClient.Email, testClient.Password, out var _);

			// Act
			AuthenticationManager.Instance.Logout();

			// Assert
			Assert.False(AuthenticationManager.Instance.IsUserLoggedIn(testClient.ID));
		}

		[Fact]
		public void CreateClientAccount_ShouldLogInClient()
		{
			// Arrange
			var testClient = TestObjects.TestClient;

			// Act
			AuthenticationManager.Instance.CreateClientAccount(context, testClient.Email, testClient.Password, testClient.CPF, testClient.FirstName, testClient.LastName);

			// Assert
			Assert.True(AuthenticationManager.Instance.IsLoggedIn);
		}

		[Fact]
		public void CreateClientAccount_ShouldThrowException_WhenEmailInUseByProvider()
		{
			// Arrange
			var testClient = TestObjects.TestClient;
			var testProvider = TestObjects.TestProvider;
			context.Providers.Add(testProvider);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<Exception>(() => AuthenticationManager.Instance.CreateClientAccount(context, testClient.Email, testClient.Password, testClient.CPF, testClient.FirstName, testClient.LastName));
		}

		[Fact]
		public void CreateClientAccount_ShouldThrowException_WhenEmailInUseByClient()
		{
			// Arrange
			var testClient = TestObjects.TestClient;
			var client = TestObjects.TestClient2;
			client.Email = testClient.Email;
			context.Clients.Add(client);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<DbUpdateException>(() => AuthenticationManager.Instance.CreateClientAccount(context, testClient.Email, testClient.Password, testClient.CPF, testClient.FirstName, testClient.LastName));
		}

		[Fact]
		public void CreateClientAccount_ShouldThrowException_WhenCPFIsInUse()
		{
			// Arrange
			var testClient = TestObjects.TestClient;
			var client = TestObjects.TestClient2;
			client.CPF = testClient.CPF;
			context.Clients.Add(client);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<DbUpdateException>(() => AuthenticationManager.Instance.CreateClientAccount(context, testClient.Email, testClient.Password, testClient.CPF, testClient.FirstName, testClient.LastName));
		}

		[Fact]
		public void CreateProviderAccount_ShouldLogInProvider()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;

			// Act
			AuthenticationManager.Instance.CreateProviderAccount(context, testProvider.Email, testProvider.Password, testProvider.Name, testProvider.CNPJ);

			// Assert
			Assert.True(AuthenticationManager.Instance.IsLoggedIn);
		}

		[Fact]
		public void CreateProviderAccount_ShouldThrowException_WhenEmailInUseByClient()
		{
			// Arrange
			var testClient = TestObjects.TestClient;
			var testProvider = TestObjects.TestProvider;
			context.Clients.Add(testClient);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<Exception>(() => AuthenticationManager.Instance.CreateProviderAccount(context, testProvider.Email, testProvider.Password, testProvider.Name, testProvider.CNPJ));
		}

		[Fact]
		public void CreateProviderAccount_ShouldThrowException_WhenEmailInUseByProvider()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var provider = TestObjects.TestProvider2;
			provider.Email = testProvider.Email;
			context.Providers.Add(provider);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<DbUpdateException>(() => AuthenticationManager.Instance.CreateProviderAccount(context, testProvider.Email, testProvider.Password, testProvider.Name, testProvider.CNPJ));
		}

		[Fact]
		public void CreateProviderAccount_ShouldThrowException_WhenCNPJInUse()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var provider = TestObjects.TestProvider2;
			provider.CNPJ = testProvider.CNPJ;
			context.Providers.Add(provider);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<DbUpdateException>(() => AuthenticationManager.Instance.CreateProviderAccount(context, testProvider.Email, testProvider.Password, testProvider.Name, testProvider.CNPJ));
		}

		[Fact]
		public void CreateProviderAccount_ShouldThrowException_WhenNameInUse()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var provider = TestObjects.TestProvider2;
			provider.Name = testProvider.Name;
			context.Providers.Add(provider);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<DbUpdateException>(() => AuthenticationManager.Instance.CreateProviderAccount(context, testProvider.Email, testProvider.Password, testProvider.Name, testProvider.CNPJ));
		}
	}
}
