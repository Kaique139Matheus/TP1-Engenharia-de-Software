using BookingDatabase.Data;
using BookingDatabase.Models;
using BookingDatabase.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace BookingDatabase.Tests
{
	[Collection("Database collection")]
	public class ClientManagerTests
	{
		private readonly EasyBookingContext context;
		private readonly ClientManager clientManager;

		private readonly ClientModel testClient = new ClientModel
		{
			Email = "test@example.com",
			Password = "password",
			CPF = "12345678900",
			FirstName = "John",
			LastName = "Doe"
		};

		public ClientManagerTests()
		{
			EasyBookingContext.TestDatabase = true;
			context = new EasyBookingContext();
			clientManager = new ClientManager(context);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}

		[Fact]
		public void UpdateClient_ShouldUpdatePassword_WhenLoggedIn()
		{
			// Arrange
			var authenticationManager = AuthenticationManager.Instance;

			context.Clients.Add(testClient);
			context.SaveChanges();

			authenticationManager.Login(context, testClient.Email, testClient.Password);

			var newPassword = "newpassword";

			// Act
			var updatedClient = clientManager.UpdateClient(testClient.ID, newPassword);
			Assert.NotNull(updatedClient);

			// Assert
			Assert.Equal(newPassword, updatedClient.Password);
		}

		[Fact]
		public void UpdateClient_ShouldThrowException_WhenInvalidClient()
		{
			// Arrange
			var newPassword = "newpassword";

			// Act & Assert
			Assert.Throws<Exception>(() => clientManager.UpdateClient(testClient.ID, newPassword));
		}

		[Fact]
		public void RemoveClient_ShouldRemoveClient_WhenLoggedIn()
		{
			// Arrange
			var authenticationManager = AuthenticationManager.Instance;

			context.Clients.Add(testClient);
			context.SaveChanges();

			authenticationManager.Login(context, testClient.Email, testClient.Password);

			// Act
			clientManager.RemoveClient(testClient.ID);

			// Assert
			Assert.Empty(context.Clients);
		}

		[Fact]
		public void RemoveClient_ShouldThrowException_WhenInvalidClient()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => clientManager.RemoveClient(testClient.ID));
		}
	}
	}