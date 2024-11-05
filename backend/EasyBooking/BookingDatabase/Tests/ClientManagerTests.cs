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

		public ClientManagerTests()
		{
			EasyBookingContext.TestDatabase = true;
			context = new EasyBookingContext();

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}

		[Fact]
		public void AddClient_ShouldAddClient()
		{
			// Arrange
			var testClient = TestObjects.TestClient;

			// Act
			var client = ClientManager.AddClient(context, testClient.Email, testClient.Password, testClient.CPF, testClient.FirstName, testClient.LastName);

			// Assert
			Assert.Equal(testClient.Email, client.Email);
			Assert.Equal(testClient.Password, client.Password);
			Assert.Equal(testClient.CPF, client.CPF);
			Assert.Equal(testClient.FirstName, client.FirstName);
			Assert.Equal(testClient.LastName, client.LastName);
		}

		[Fact]
		public void UpdateClient_ShouldUpdatePassword()
		{
			// Arrange
			var testClient = TestObjects.TestClient;
			context.Clients.Add(testClient);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testClient.Email, testClient.Password, out var _);

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
			// Act & Assert
			Assert.Throws<Exception>(() => ClientManager.UpdateClient(context, 0, "newpassword"));
		}

		[Fact]
		public void RemoveClient_ShouldRemoveClient()
		{
			// Arrange
			var testClient = TestObjects.TestClient;
			context.Clients.Add(testClient);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testClient.Email, testClient.Password, out var _);

			// Act
			ClientManager.RemoveClient(context, testClient.ID);

			// Assert
			Assert.Empty(context.Clients);
		}

		[Fact]
		public void RemoveClient_ShouldThrowException_WhenInvalidClient()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => ClientManager.RemoveClient(context, 0));
		}
	}
	}