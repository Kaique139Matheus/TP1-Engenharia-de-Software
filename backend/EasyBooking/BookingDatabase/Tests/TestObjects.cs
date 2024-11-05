using BookingDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Tests
{
	/// <summary>
	/// Hardcoded test objects for use in tests.
	/// </summary>
	public static class TestObjects
	{
		public static ClientModel TestClient => new ClientModel
		{
			Email = "test@example.com",
			Password = "password",
			CPF = "12345678900",
			FirstName = "John",
			LastName = "Doe"
		};

		public static ClientModel TestClient2 => new ClientModel
		{
			Email = "test2@example.com",
			Password = "password",
			CPF = "12345678901",
			FirstName = "Jane",
			LastName = "Doe"
		};

		public static ProviderModel TestProvider => new ProviderModel
		{
			Email = "test@example.com",
			Password = "password",
			Name = "Test Provider",
			CNPJ = "12345678901234"
		};

		public static ProviderModel TestProvider2 => new ProviderModel
		{
			Email = "test2@example.com",
			Password = "password",
			Name = "Test Provider 2",
			CNPJ = "12345678901235"
		};

		public static ServiceModel TestService => new ServiceModel
		{
			Name = "Test Service",
			Description = "Just a test",
			Price = 100,
			DurationInMinutes = 60,
			ProviderID = 1
		};

		public static ServiceModel TestService2 => new ServiceModel
		{
			Name = "Test Service 2",
			Description = "Just a test",
			Price = 100,
			DurationInMinutes = 60,
			ProviderID = 1
		};

		public static TimeslotModel TestTimeslot => new TimeslotModel
		{
			Time = 1200,
			ServiceID = 1
		};

		public static TimeslotModel TestTimeslot2 => new TimeslotModel
		{
			Time = 1300,
			ServiceID = 1
		};

		public static ReviewModel TestReview => new ReviewModel
		{
			Score = 5,
			Comment = "Great service!",
			ClientID = 1,
			ProviderID = 1
		};

		public static ReviewModel TestReview2 => new ReviewModel
		{
			Score = 3,
			Comment = "Could be better...",
			ClientID = 1,
			ProviderID = 1
		};
	}
}
