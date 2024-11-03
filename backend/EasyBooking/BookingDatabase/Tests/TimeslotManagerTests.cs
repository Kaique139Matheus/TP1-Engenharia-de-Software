using BookingDatabase.Data;
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
	public class TimeslotManagerTests
	{
		private readonly EasyBookingContext context;

		public TimeslotManagerTests()
		{
			EasyBookingContext.TestDatabase = true;
			context = new EasyBookingContext();

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}

		[Fact]
		public void AddTimeslot_ShouldAddTimeslot()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var testService = TestObjects.TestService;
			var testTimeslot = TestObjects.TestTimeslot;
			context.Providers.Add(testProvider);
			context.Services.Add(testService);
			context.SaveChanges();

			// Act
			var timeslot = TimeslotManager.AddTimeslot(context, testService.ID, testTimeslot.Time);

			// Assert
			Assert.Equal(testService.ID, timeslot.ServiceID);
			Assert.Equal(testTimeslot.Time, timeslot.Time);
		}

		[Fact]
		public void ValidateAndGetServiceTimeslot_ShouldReturnTimeslot()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var testService = TestObjects.TestService;
			var testTimeslot = TestObjects.TestTimeslot;
			context.Providers.Add(testProvider);
			context.Services.Add(testService);
			context.Timeslots.Add(testTimeslot);
			context.SaveChanges();

			// Act
			var timeslot = TimeslotManager.ValidateAndGetServiceTimeslot(context, testTimeslot.ID, testService.ID, testProvider.ID);

			// Assert
			Assert.NotNull(timeslot);
			Assert.Equal(testTimeslot.ID, timeslot.ID);
		}

		[Fact]
		public void ValidateAndGetServiceTimeslot_ShouldThrowException_WhenInvalidTimeslot()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var testService = TestObjects.TestService;
			var testTimeslot = TestObjects.TestTimeslot;
			context.Providers.Add(testProvider);
			context.Services.Add(testService);
			context.Timeslots.Add(testTimeslot);
			context.SaveChanges();

			// Act and Assert
			Assert.Throws<Exception>(() => TimeslotManager.ValidateAndGetServiceTimeslot(context, -1, testService.ID, testProvider.ID));
		}

		[Fact]
		public void ValidateAndGetServiceTimeslot_ShouldThrowException_WhenTimeslotDoesNotBelongToService()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var testService = TestObjects.TestService;
			var testService2 = TestObjects.TestService2;
			var testTimeslot = TestObjects.TestTimeslot;
			context.Providers.Add(testProvider);
			context.Services.Add(testService);
			context.Services.Add(testService2);
			context.Timeslots.Add(testTimeslot);
			context.SaveChanges();

			// Act and Assert
			Assert.Throws<Exception>(() => TimeslotManager.ValidateAndGetServiceTimeslot(context, testTimeslot.ID, testService2.ID, testProvider.ID));
		}

		[Fact]
		public void UpdateTimeslot_ShouldUpdateTime()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var testService = TestObjects.TestService;
			var testTimeslot = TestObjects.TestTimeslot;
			context.Providers.Add(testProvider);
			context.Services.Add(testService);
			context.Timeslots.Add(testTimeslot);
			context.SaveChanges();

			var newTime = 1230;

			// Act
			var updatedTimeslot = TimeslotManager.UpdateTimeslot(context, testTimeslot.ID, testService.ID, testProvider.ID, newTime);
			Assert.NotNull(updatedTimeslot);

			// Assert
			Assert.Equal(newTime, updatedTimeslot.Time);
		}

		[Fact]
		public void RemoveTimeslot_ShouldRemoveTimeslot()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var testService = TestObjects.TestService;
			var testTimeslot = TestObjects.TestTimeslot;
			context.Providers.Add(testProvider);
			context.Services.Add(testService);
			context.Timeslots.Add(testTimeslot);
			context.SaveChanges();

			// Act
			TimeslotManager.RemoveTimeslot(context, testTimeslot.ID, testService.ID, testProvider.ID);

			// Assert
			Assert.Empty(context.Timeslots);
		}

		[Fact]
		public void GetServiceTimeslots_ShouldReturnTimeslots()
		{
			// Arrange
			var testProvider = TestObjects.TestProvider;
			var testService = TestObjects.TestService;
			var testTimeslot = TestObjects.TestTimeslot;
			var testTimeslot2 = TestObjects.TestTimeslot2;
			context.Providers.Add(testProvider);
			context.Services.Add(testService);
			context.Timeslots.Add(testTimeslot);
			context.Timeslots.Add(testTimeslot2);
			context.SaveChanges();

			// Act
			var timeslots = TimeslotManager.GetServiceTimeslots(context, testService.ID);

			// Assert
			Assert.Equal(2, timeslots.Count);
			Assert.Contains(testTimeslot, timeslots);
			Assert.Contains(testTimeslot2, timeslots);
		}
	}
}
