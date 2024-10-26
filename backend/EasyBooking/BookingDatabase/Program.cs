using BookingDatabase.Data;
using BookingDatabase.Models;


using var db = new EasyBookingContext();

db.Database.EnsureDeleted();
db.Database.EnsureCreated();

Console.WriteLine($"Database path: {db.DbPath}");

// Create new provider
Console.WriteLine("Creating new provider");
db.Add(new ProviderModel
{
	Name = "Provider 1",
	Email = "provider1@db.com",
	Password = "provider1",
	CNPJ = "12345678901234",
});
db.SaveChanges();

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
