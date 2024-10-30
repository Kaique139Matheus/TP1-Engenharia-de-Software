using BookingDatabase.Data;
using BookingDatabase.Models;
using BookingDatabase.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace BookingDatabase.Tests
{
	public class ClientServiceTests
	{
		private readonly EasyBookingContext context;
		private readonly ClientService clientService;

		private readonly ClientModel testClient = new ClientModel
		{
			Email = "test@example.com",
			Password = "password",
			CPF = "12345678900",
			FirstName = "John",
			LastName = "Doe"
		};

		public ClientServiceTests()
		{
			bool isTesting = true;
			context = new EasyBookingContext(isTesting);
			clientService = new ClientService(context);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}

		[Fact]
		public void AddClient_ShouldAddClient_WhenEmailIsNotInUse()
		{
			// Act
			var client = clientService.AddClient(testClient.Email, testClient.Password, testClient.CPF, testClient.FirstName, testClient.LastName);

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
			Assert.Throws<Exception>(() => clientService.AddClient(testClient.Email, testClient.Password, testClient.CPF, testClient.FirstName, testClient.LastName));
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
			Assert.Throws<DbUpdateException>(() => clientService.AddClient(testClient.Email, testClient.Password, testClient.CPF, testClient.FirstName, testClient.LastName));
		}

		[Fact]
		public void UpdateClient_ShouldUpdatePassword_WhenClientExists()
		{
			// Arrange
			context.Clients.Add(testClient);
			context.SaveChanges();

			var newPassword = "newpassword";

			// Act
			var updatedClient = clientService.UpdateClient(testClient.ID, newPassword);
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
			Assert.Throws<Exception>(() => clientService.UpdateClient(testClient.ID, newPassword));
		}

		[Fact]
		public void RemoveClient_ShouldRemoveClient_WhenClientExists()
		{
			// Arrange
			context.Clients.Add(testClient);
			context.SaveChanges();

			// Act
			clientService.RemoveClient(testClient.ID);

			// Assert
			Assert.Empty(context.Clients);
		}

		[Fact]
		public void RemoveClient_ShouldThrowException_WhenClientDoesNotExist()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => clientService.RemoveClient(testClient.ID));
		}
	}
	}