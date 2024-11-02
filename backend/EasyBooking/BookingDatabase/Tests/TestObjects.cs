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
	}
}
