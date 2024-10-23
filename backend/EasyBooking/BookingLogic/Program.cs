using BookingDatabase.Data;
using BookingDatabase.Models;

public class Test
{
	public static void Main(string[] args)
	{
		CreateClient("John", "Doe", "admin", "admin", "12345678900");
		CreateProvider("Provider", "admin", "admin", "12345678900000");
		LogIn("admin", "admin");
	}

	public static void CreateClient(string firstName, string lastName, string email, string password, string cpf)
	{
		var db = new EasyBookingContext();

		// Check if the email is already in the Providers table
		var provider = db.Providers.FirstOrDefault(p => p.Email == email);
		if (provider != null)
		{
			Console.WriteLine("Email in use!");
			return;
		}

		var client = new ClientModel
		{
			FirstName = firstName,
			LastName = lastName,
			Email = email,
			Password = password,
			CPF = cpf
		};

		db.Clients.Add(client);
		db.SaveChanges();
	}

	public static void CreateProvider(string name, string email, string password, string cnpj)
	{
		var db = new EasyBookingContext();

		// Check if the email is already in the Clients table
		var client = db.Clients.FirstOrDefault(c => c.Email == email);
		if (client != null)
		{
			Console.WriteLine("Email in use!");
			return;
		}

		var provider = new ProviderModel
		{
			Name = name,
			Email = email,
			Password = password,
			CNPJ = cnpj
		};

		db.Providers.Add(provider);
		db.SaveChanges();
	}

	public static void LogIn(string email, string password)
	{
		var db = new EasyBookingContext();

		var client = db.Clients.FirstOrDefault(c => c.Email == email);
		var provider = db.Providers.FirstOrDefault(p => p.Email == email);

		if (client != null)
		{
			if (password == client.Password)
			{
				Console.WriteLine($"Welcome, {client.FirstName} {client.LastName}");
			}
			else
			{
				Console.WriteLine("Wrong password");
			}
		}
		if (provider != null)
		{
			if (password == provider.Password)
			{
				Console.WriteLine($"Welcome, {provider.Name}");
			}
			else
			{
				Console.WriteLine("Wrong password");
			}
		}

		if(client == null && provider == null)
		{
			Console.WriteLine("User not found");
		}
		if (client != null && provider != null)
		{
			Console.WriteLine("Duplicate email error!");
		}
	}
}