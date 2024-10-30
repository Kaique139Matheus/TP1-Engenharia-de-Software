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
			bool isTesting = true;
			context = new EasyBookingContext(isTesting);
			clientManager = new ClientManager(context);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}

		[Fact]
		public void AddClient_ShouldAddClient()
		{
			// Act
			var client = clientManager.AddClient(testClient.Email, testClient.Password, testClient.CPF, testClient.FirstName, testClient.LastName);

			// Assert
			Assert.NotNull(testClient);
		}

		[Fact]
		public void AddClient_ShouldThrowException_WhenEmailIsInUse()
		{
			// Arrange
			var provider = new ProviderModel
			{
				Email = "test@example.com",
				Password = "password",
				Name = "Test Provider",
				CNPJ = "12345678901234"
			};

			context.Providers.Add(provider);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<Exception>(() => clientManager.AddClient(testClient.Email, testClient.Password, testClient.CPF, testClient.FirstName, testClient.LastName));
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
			Assert.Throws<DbUpdateException>(() => clientManager.AddClient(testClient.Email, testClient.Password, testClient.CPF, testClient.FirstName, testClient.LastName));
		}

		[Fact]
		public void UpdateClient_ShouldUpdatePassword_WhenClientExists()
		{
			// Arrange
			context.Clients.Add(testClient);
			context.SaveChanges();

			var newPassword = "newpassword";

			// Act
			var updatedClient = clientManager.UpdateClient(testClient.ID, newPassword);
			Assert.NotNull(updatedClient);

			// Assert
			Assert.Equal(newPassword, updatedClient.Password);
		}

		[Fact]
		public void UpdateClient_ShouldThrowException_WhenClientDoesNotExist()
		{
			// Arrange
			var newPassword = "newpassword";

			// Act & Assert
			Assert.Throws<Exception>(() => clientManager.UpdateClient(testClient.ID, newPassword));
		}

		[Fact]
		public void RemoveClient_ShouldRemoveClient_WhenClientExists()
		{
			// Arrange
			context.Clients.Add(testClient);
			context.SaveChanges();

			// Act
			clientManager.RemoveClient(testClient.ID);

			// Assert
			Assert.Empty(context.Clients);
		}

		[Fact]
		public void RemoveClient_ShouldThrowException_WhenClientDoesNotExist()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => clientManager.RemoveClient(testClient.ID));
		}
	}
	}