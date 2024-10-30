using BookingDatabase.Data;
using BookingDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Services
{
	public class AuthenticationService
	{
		private readonly EasyBookingContext context;

		private UserModel? currentUser;

		public bool IsProvider { get; private set; }
		public bool IsLoggedIn => currentUser != null;

		public AuthenticationService(EasyBookingContext context)
		{
			this.context = context;
			this.currentUser = null;
		}

		public void Login(string email, string password)
		{
			var client = context.Clients.SingleOrDefault(c => c.Email == email);
			var provider = context.Providers.SingleOrDefault(p => p.Email == email);

			if (client == null && provider == null) throw new Exception("Email not found");
			else if (client != null)
			{
				if (client.Password != password) throw new Exception("Incorrect password");
				currentUser = client;
				IsProvider = false;
			}
			else if (provider != null)
			{
				if (provider.Password != password) throw new Exception("Incorrect password");
				currentUser = provider;
				IsProvider = true;
			}
		}

		public void Logout()
		{
			currentUser = null;
		}
	}
}
