﻿using BookingDatabase.Data;
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
		public void UpdateProvider_ShouldUpdatePassword()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			context.Providers.Add(testProvider);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testProvider.Email, testProvider.Password);

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

			AuthenticationManager.Instance.Login(context, testProvider.Email, testProvider.Password);

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