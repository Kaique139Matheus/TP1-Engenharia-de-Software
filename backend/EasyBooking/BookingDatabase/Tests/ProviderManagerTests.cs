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
	public class ProviderManagerTests
	{
		private readonly EasyBookingContext context;
		private readonly ProviderManager providerManager;

		private readonly ProviderModel testProvider = new ProviderModel
		{
			Email = "test@example.com",
			Password = "password",
			Name = "Test Provider",
			CNPJ = "12345678901234"
		};

		private readonly ProviderModel testProvider2 = new ProviderModel
		{
			Email = "test2@example.com",
			Password = "password",
			Name = "Test Provider 2",
			CNPJ = "12345678901235"
		};

		public ProviderManagerTests()
		{
			bool isTesting = true;
			context = new EasyBookingContext(isTesting);
			providerManager = new ProviderManager(context);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}

		[Fact]
		public void AddProvider_ShouldAddProvider()
		{
			// Act
			var provider = providerManager.AddProvider(testProvider.Email, testProvider.Password, testProvider.Name, testProvider.CNPJ);

			// Assert
			Assert.NotNull(provider);
		}

		[Fact]
		public void AddProvider_ShouldThrowException_WhenEmailIsInUse()
		{
			// Arrange
			var client = new ClientModel
			{
				Email = testProvider.Email,
				Password = "password",
				CPF = "12345678900",
				FirstName = "John",
				LastName = "Doe"
			};

			context.Clients.Add(client);
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<Exception>(() => providerManager.AddProvider(testProvider.Email, testProvider.Password, testProvider.Name, testProvider.CNPJ));
		}

		[Fact]
		public void AddProvider_ShouldThrowException_WhenCNPJIsInUse()
		{
			// Arrange
			context.Providers.Add(new ProviderModel
			{
				Email = testProvider2.Email,
				Password = testProvider2.Password,
				Name = testProvider2.Name,
				CNPJ = testProvider.CNPJ
			});
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<DbUpdateException>(() => providerManager.AddProvider(testProvider.Email, testProvider.Password, testProvider.Name, testProvider.CNPJ));
		}

		[Fact]
		public void AddProvider_ShouldThrowException_WhenNameIsInUse()
		{
			// Arrange
			context.Providers.Add(new ProviderModel
			{
				Email = testProvider2.Email,
				Password = testProvider2.Password,
				Name = testProvider.Name,
				CNPJ = testProvider2.CNPJ
			});
			context.SaveChanges();

			// Act & Assert
			Assert.Throws<DbUpdateException>(() => providerManager.AddProvider(testProvider.Email, testProvider.Password, testProvider.Name, testProvider.CNPJ));
		}

		[Fact]
		public void UpdateProvider_ShouldUpdatePassword_WhenProviderExists()
		{
			// Arrange
			context.Providers.Add(testProvider);
			context.SaveChanges();

			var newPassword = "newpassword";

			// Act
			var provider = providerManager.UpdateProvider(testProvider.ID, newPassword);

			// Assert
			Assert.Equal(newPassword, provider.Password);
		}

		[Fact]
		public void UpdateProvider_ShouldThrowException_WhenProviderNotFound()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => providerManager.UpdateProvider(0, "newpassword"));
		}

		[Fact]
		public void DeleteProvider_ShouldDeleteProvider()
		{
			// Arrange
			context.Providers.Add(testProvider);
			context.SaveChanges();

			// Act
			providerManager.DeleteProvider(testProvider.ID);

			// Assert
			Assert.Empty(context.Providers);
		}

		[Fact]
		public void DeleteProvider_ShouldThrowException_WhenProviderNotFound()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => providerManager.DeleteProvider(0));
		}
	}
}