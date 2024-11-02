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

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}

		[Fact]
		public void UpdateClient_ShouldUpdatePassword()
		{
			// Arrange
			context.Clients.Add(testClient);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testClient.Email, testClient.Password);

			var newPassword = "newpassword";

			// Act
			var updatedClient = ClientManager.UpdateClient(context, testClient.ID, newPassword);
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
			Assert.Throws<Exception>(() => ClientManager.UpdateClient(context, testClient.ID, newPassword));
		}

		[Fact]
		public void RemoveClient_ShouldRemoveClient()
		{
			// Arrange
			context.Clients.Add(testClient);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testClient.Email, testClient.Password);

			// Act
			ClientManager.RemoveClient(context, testClient.ID);

			// Assert
			Assert.Empty(context.Clients);
		}

		[Fact]
		public void RemoveClient_ShouldThrowException_WhenInvalidClient()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => ClientManager.RemoveClient(context, testClient.ID));
		}
	}
	}