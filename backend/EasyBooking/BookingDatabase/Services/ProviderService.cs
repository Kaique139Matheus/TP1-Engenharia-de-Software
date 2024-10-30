using BookingDatabase.Data;
using BookingDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Services
{
	public class ProviderService
	{
		private readonly EasyBookingContext context;

		public ProviderService(EasyBookingContext context)
		{
			this.context = context;
		}

		public ProviderModel AddProvider(string email, string password, string name, string CNPJ)
		{
			// Verify that the email is not already in use in the Clients table
			if (context.Clients.Any(c => c.Email == email)) throw new Exception("Email in use");

			var provider = new ProviderModel
			{
				Email = email,
				Password = password,
				Name = name,
				CNPJ = CNPJ
			};

			context.Providers.Add(provider);
			context.SaveChanges();

			return provider;
		}

		public ProviderModel UpdateProvider(int id, string newPassword)
		{
			var provider = context.Providers.Find(id);
			if (provider == null) throw new Exception("Provider not found");

			provider.Password = newPassword;
			context.SaveChanges();

			return provider;
		}

		public void DeleteProvider(int id) 
		{
			var provider = context.Providers.Find(id);
			if (provider == null) throw new Exception("Provider not found");

			context.Providers.Remove(provider);
			context.SaveChanges();
		}
	}
}
