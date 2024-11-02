using BookingDatabase.Data;
using BookingDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Services
{
	public class ClientManager
	{
		private readonly EasyBookingContext context;

		public ClientManager(EasyBookingContext context)
		{
			this.context = context;
		}

		public ClientModel AddClient(string email, string password, string CPF, string firstName, string lastName)
		{
			var client = new ClientModel
			{
				Email = email,
				Password = password,
				CPF = CPF,
				FirstName = firstName,
				LastName = lastName
			};

			context.Clients.Add(client);
			context.SaveChanges();

			return client;
		}

		public ClientModel UpdateClient(int id, string newPassword) 
		{
			if (!AuthenticationManager.Instance.IsUserLoggedIn(id)) throw new Exception("User not logged in");

			var client = context.Clients.Find(id);
			if (client == null) throw new Exception("Client not found");

			client.Password = newPassword;
			context.SaveChanges();

			return client;
		}

		public void RemoveClient(int id)
		{
			var client = context.Clients.Find(id);
			if (client == null) throw new Exception("Client not found");

			context.Clients.Remove(client);
			context.SaveChanges();
		}
	}
}
