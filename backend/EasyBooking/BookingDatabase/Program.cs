using BookingDatabase.Data;
using BookingDatabase.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;



class Program
{

	static void Main(string[] args)
	{
		#region Creating and testing

		using var db = new EasyBookingContext();
		db.Database.EnsureDeleted();
		db.Database.EnsureCreated();

		Console.WriteLine($"Database path: {db.DbPath}");

		// Create new provider  
		Console.WriteLine("Creating new providers");

		var provider1 = new ProviderModel
		{
			Name = "Provider 1",
			Email = "provider1@db.com",
			Password = "provider1",
			CNPJ = "12345678901234",
		};

		db.Add(provider1);
		db.SaveChanges();

		Console.WriteLine($"{provider1.Name} created");

		var provider2 = new ProviderModel
		{
			Name = "Provider 2",
			Email = "provider2@db.com",
			Password = "provider2",
			CNPJ = "12345678901235",
		};

		db.Add(provider2);
		db.SaveChanges();

		Console.WriteLine($"{provider2.Name} created");

		// Query all providers  
		Console.WriteLine("Querying all providers");
		var providers = db.Providers.ToList();
		foreach (var provider in providers)
		{
			Console.WriteLine($"Provider {provider.ID}: {provider.Name} ({provider.Email})");
		}

		// Create new service  
		var service1 = new ServiceModel
		{
			Name = "Service 1",
			Description = "Service 1 description",
			Price = 100,
			DurationInMinutes = 60,
			ProviderID = 1,
		};
		db.Add(service1);

		Console.WriteLine($"Created {service1.Name} for {db.Providers.Find(service1.ProviderID)?.Name}");

		var timeslot1 = new TimeslotModel
		{
			Time = 1200,
			ServiceID = 1,
		};
		db.Add(timeslot1);

		Console.WriteLine($"Created new timeslot at time {timeslot1.Time} for service {timeslot1.ServiceID}");

		var client1 = new ClientModel
		{
			Email = "client1@db.com",
			Password = "client1",
			CPF = "12345678901",
			FirstName = "Client",
			LastName = "1",
		};
		db.Add(client1);

		Console.WriteLine($"Created new client {client1.FirstName} {client1.LastName} ({client1.Email})");

		db.SaveChanges();

		//// Count providers  
		//Console.WriteLine($"There are {db.Providers.Count()} providers in the database");
		//// Count services  
		//Console.WriteLine($"There are {db.Services.Count()} services in the database");
		//// Count timeslots
		//Console.WriteLine($"There are {db.Timeslots.Count()} timeslots in the database");

		//Console.WriteLine($"Deleting {provider1.Name}");
		//db.Remove(provider1);
		//db.SaveChanges();

		// Count providers  
		Console.WriteLine($"There are {db.Providers.Count()} providers in the database");
		// Count services  
		Console.WriteLine($"There are {db.Services.Count()} services in the database");
		// Count timeslots
		Console.WriteLine($"There are {db.Timeslots.Count()} timeslots in the database");

		#endregion

		CreateHostBuilder(args).Build().Run();
	}

	public static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
			.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseStartup<Startup>();
			});
}
