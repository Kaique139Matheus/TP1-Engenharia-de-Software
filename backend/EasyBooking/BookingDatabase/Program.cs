using BookingDatabase.Data;
using BookingDatabase.Models;

class Program
{
	static void Main(string[] args)
	{

		using var db = new EasyBookingContext();
		db.Database.EnsureDeleted();
		db.Database.EnsureCreated();

		Console.WriteLine($"Database path: {db.DbPath}");

		// Create new provider  
		Console.WriteLine("Creating new provider");

		var testProvider = new ProviderModel
		{
			Name = "Provider 1",
			Email = "provider1@db.com",
			Password = "provider1",
			CNPJ = "12345678901234",
		};

		db.Add(testProvider);
		db.SaveChanges();

		Console.WriteLine($"Provider {testProvider.ID} created");

		var testProvider2 = new ProviderModel
		{
			Name = "Provider 2",
			Email = "provider2@db.com",
			Password = "provider2",
			CNPJ = "12345678901235",
		};

		db.Add(testProvider2);
		db.SaveChanges();

		Console.WriteLine($"Provider {testProvider2.ID} created");

		// Query all providers  
		Console.WriteLine("Querying all providers");
		var providers = db.Providers.ToList();
		foreach (var provider in providers)
		{
			Console.WriteLine($"Provider {provider.ID}: {provider.Name} ({provider.Email})");
		}

		// Create new service  
		Console.WriteLine("Creating new service");
		db.Add(new ServiceModel
		{
			Name = "Service 1",
			Description = "Service 1 description",
			Price = 100,
			DurationInMinutes = 60,
			ProviderID = 1,
		});
		db.SaveChanges();

		// Count providers  
		Console.WriteLine($"There are {db.Providers.Count()} providers in the database");
		// Count services  
		Console.WriteLine($"There are {db.Services.Count()} services in the database");
	}
}
