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
			EasyBookingContext.TestDatabase = true;
			context = new EasyBookingContext();
			providerManager = new ProviderManager(context);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}

		[Fact]
		public void UpdateProvider_ShouldUpdatePassword_WhenLoggedIn()
		{
			// Arrange
			context.Providers.Add(testProvider);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testProvider.Email, testProvider.Password);

			var newPassword = "newpassword";

			// Act
			var provider = providerManager.UpdateProvider(testProvider.ID, newPassword);

			// Assert
			Assert.Equal(newPassword, provider.Password);
		}

		[Fact]
		public void UpdateProvider_ShouldThrowException_WhenInvalidProvider()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => providerManager.UpdateProvider(0, "newpassword"));
		}

		[Fact]
		public void DeleteProvider_ShouldDeleteProvider_WhenLoggedIn()
		{
			// Arrange
			context.Providers.Add(testProvider);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testProvider.Email, testProvider.Password);

			// Act
			providerManager.DeleteProvider(testProvider.ID);

			// Assert
			Assert.Empty(context.Providers);
		}

		[Fact]
		public void DeleteProvider_ShouldThrowException_WhenInvalidProvider()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => providerManager.DeleteProvider(0));
		}
	}
}