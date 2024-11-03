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
	public class ServiceManagerTests
	{
		private readonly EasyBookingContext context;

		public ServiceManagerTests()
		{
			EasyBookingContext.TestDatabase = true;
			context = new EasyBookingContext();

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}

		[Fact]
		public void AddService_ShouldAddService()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var testService = TestObjects.TestService;
			context.Providers.Add(testProvider);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testProvider.Email, testProvider.Password);

			// Act
			var service = ServiceManager.AddService(context, testProvider.ID, testService.Name, testService.Description, testService.Price, testService.DurationInMinutes);

			// Assert
			Assert.Equal(testService.Name, service.Name);
			Assert.Equal(testService.Description, service.Description);
			Assert.Equal(testService.Price, service.Price);
			Assert.Equal(testService.DurationInMinutes, service.DurationInMinutes);
		}

		[Fact]
		public void AddService_ShouldThrowException_WhenInvalidProvider()
		{
			// Arrange
			var testService = TestObjects.TestService;

			// Act & Assert
			Assert.Throws<Exception>(() => ServiceManager.AddService(context, 0, testService.Name, testService.Description, testService.Price, testService.DurationInMinutes));
		}

		[Fact]
		public void ValidateAndGetProviderService_ShouldReturnService()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var testService = TestObjects.TestService;
			context.Providers.Add(testProvider);
			context.Services.Add(testService);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testProvider.Email, testProvider.Password);

			// Act
			var service = ServiceManager.ValidateAndGetProviderService(context, testProvider.ID, testService.ID);

			// Assert
			Assert.NotNull(service);
			Assert.Equal(testService.ID, service.ID);
		}

		[Fact]
		public void ValidateAndGetProviderService_ShouldThrowException_WhenInvalidProvider()
		{
			// Act & Assert
			Assert.Throws<Exception>(() => ServiceManager.ValidateAndGetProviderService(context, 0, 0));
		}

		[Fact]
		public void ValidateAndGetProviderService_ShouldThrowException_WhenInvalidService()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var testService = TestObjects.TestService;
			context.Providers.Add(testProvider);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testProvider.Email, testProvider.Password);

			// Act & Assert
			Assert.Throws<Exception>(() => ServiceManager.ValidateAndGetProviderService(context, testProvider.ID, testService.ID));
		}

		[Fact]
		public void ValidateAndGetProviderService_ShouldThrowException_WhenServiceDoesNotBelongToProvider()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var testProvider2 = TestObjects.TestProvider2;
			var testService = TestObjects.TestService;
			context.Providers.Add(testProvider);
			context.Providers.Add(testProvider2);
			context.Services.Add(testService);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testProvider2.Email, testProvider2.Password);

			// Act & Assert
			Assert.Throws<Exception>(() => ServiceManager.ValidateAndGetProviderService(context, testProvider2.ID, testService.ID));
		}

		[Fact]
		public void UpdateService_ShouldUpdateService()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var testService = TestObjects.TestService;
			context.Providers.Add(testProvider);
			context.Services.Add(testService);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testProvider.Email, testProvider.Password);

			var newName = "New Name";
			var newDescription = "New Description";
			var newPrice = 200;

			// Act
			var updatedService = ServiceManager.UpdateService(context, testProvider.ID, testService.ID, newName, newDescription, newPrice);

			// Assert
			Assert.Equal(newName, updatedService.Name);
			Assert.Equal(newDescription, updatedService.Description);
			Assert.Equal(newPrice, updatedService.Price);
		}

		[Fact]
		public void RemoveService_ShouldRemoveService()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var testService = TestObjects.TestService;
			context.Providers.Add(testProvider);
			context.Services.Add(testService);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testProvider.Email, testProvider.Password);

			// Act
			ServiceManager.RemoveService(context, testProvider.ID, testService.ID);

			// Assert
			Assert.Empty(context.Services);
		}

		[Fact]
		public void GetProviderServices_ShouldReturnProviderServices()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var testService = TestObjects.TestService;
			var testService2 = TestObjects.TestService2;
			context.Providers.Add(testProvider);
			context.Services.Add(testService);
			context.Services.Add(testService2);
			context.SaveChanges();

			AuthenticationManager.Instance.Login(context, testProvider.Email, testProvider.Password);

			// Act
			var services = ServiceManager.GetProviderServices(context, testProvider.ID);

			// Assert
			Assert.Equal(2, services.Count);
			Assert.Contains(testService, services);
			Assert.Contains(testService2, services);
		}
	}
}
