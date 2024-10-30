using BookingDatabase.Data;
using BookingDatabase.Models;
using BookingDatabase.Services;
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
		private readonly AuthenticationManager authenticationManager;

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
			bool isTesting = true;
			context = new EasyBookingContext(isTesting);
			authenticationManager = new AuthenticationManager(context);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}

		[Fact]
		public void Login_ShouldLoginClient()
		{
			// Arrange
			context.Clients.Add(testClient);
			context.SaveChanges();

			// Act
			authenticationManager.Login(testClient.Email, testClient.Password);

			// Assert
			Assert.True(authenticationManager.IsLoggedIn);
		}

		[Fact]
		public void Login_ShouldLoginProvider()
		{
			// Arrange
			context.Providers.Add(testProvider);
			context.SaveChanges();

			// Act
			authenticationManager.Login(testProvider.Email, testProvider.Password);

			// Assert
			Assert.True(authenticationManager.IsLoggedIn);
		}

		[Fact]
		public void Login_ShouldThrowException_WhenEmailNotFound()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => authenticationManager.Login(testClient.Email, testClient.Password));
		}

		[Fact]
		public void Login_ShouldThrowException_WhenIncorrectPassword()
		{
			// Arrange
			context.Clients.Add(testClient);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<Exception>(() => authenticationManager.Login(testClient.Email, "wrongpassword"));
		}

		[Fact]
		public void Logout_ShouldLogout()
		{
			// Arrange
			context.Clients.Add(testClient);
			context.SaveChanges();
			authenticationManager.Login(testClient.Email, testClient.Password);

			// Act
			authenticationManager.Logout();

			// Assert
			Assert.False(authenticationManager.IsLoggedIn);
		}

	}
}
