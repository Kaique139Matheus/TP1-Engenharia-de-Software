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

		public ProviderManagerTests()
		{
			EasyBookingContext.TestDatabase = true;
			context = new EasyBookingContext();

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}

		[Fact]
		public void AddProvider_ShouldAddProvider()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;

			// Act
			var provider = ProviderManager.AddProvider(context, testProvider.Email, testProvider.Password, testProvider.Name, testProvider.CNPJ);

			// Assert
			Assert.Equal(testProvider.Email, provider.Email);
			Assert.Equal(testProvider.Password, provider.Password);
			Assert.Equal(testProvider.CNPJ, provider.CNPJ);
			Assert.Equal(testProvider.Name, provider.Name);
		}

		[Fact]
		public void UpdateProvider_ShouldUpdatePassword()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			context.Providers.Add(testProvider);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testProvider.Email, testProvider.Password, out var _);

			var newPassword = "newpassword";

			// Act
			var provider = ProviderManager.UpdateProvider(context, testProvider.ID, newPassword);

			// Assert
			Assert.Equal(newPassword, provider.Password);
		}

		[Fact]
		public void UpdateProvider_ShouldThrowException_WhenInvalidProvider()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => ProviderManager.UpdateProvider(context, 0, "newpassword"));
		}

		[Fact]
		public void DeleteProvider_ShouldDeleteProvider()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			context.Providers.Add(testProvider);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testProvider.Email, testProvider.Password, out var _);

			// Act
			ProviderManager.DeleteProvider(context, testProvider.ID);

			// Assert
			Assert.Empty(context.Providers);
		}

		[Fact]
		public void DeleteProvider_ShouldThrowException_WhenInvalidProvider()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => ProviderManager.DeleteProvider(context, 0));
		}
	}
}