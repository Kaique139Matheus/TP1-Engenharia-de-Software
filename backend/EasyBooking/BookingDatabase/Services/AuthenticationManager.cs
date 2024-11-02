using BookingDatabase.Data;
using BookingDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Services
{
	public class AuthenticationManager
	{
		private static AuthenticationManager? instance;

		public static AuthenticationManager Instance 
		{ 
			get
			{
				if (instance == null) instance = new AuthenticationManager();
				return instance;
			}

			private set { Instance = value; }
		}

		public UserModel? CurrentUser {  get; private set; }

		public bool IsProvider { get; private set; }
		public bool IsLoggedIn => CurrentUser != null;
		public bool IsUserLoggedIn(int id) => CurrentUser != null && CurrentUser.ID == id;

		private AuthenticationManager()
		{
			this.CurrentUser = null;
		}

		public void Login(EasyBookingContext context, string email, string password)
		{
			var client = context.Clients.SingleOrDefault(c => c.Email == email);
			var provider = context.Providers.SingleOrDefault(p => p.Email == email);

			if (client == null && provider == null) throw new Exception("Email not found");
			else if (client != null)
			{
				if (client.Password != password) throw new Exception("Incorrect password");
				CurrentUser = client;
				IsProvider = false;
			}
			else if (provider != null)
			{
				if (provider.Password != password) throw new Exception("Incorrect password");
				CurrentUser = provider;
				IsProvider = true;
			}
		}

		public void Logout()
		{
			CurrentUser = null;
		}

		public void CreateClientAccount(EasyBookingContext context, string email, string password, string CPF, string firstName, string lastName)
		{
			if (context.Providers.Any(p => p.Email == email)) throw new Exception("Email in use");

			var user = ClientManager.AddClient(context, email, password, CPF, firstName, lastName);

			CurrentUser = user;
			IsProvider = false;
		}

		public void CreateProviderAccount(EasyBookingContext context, string email, string password, string name, string CNPJ)
		{
			if (context.Clients.Any(c => c.Email == email)) throw new Exception("Email in use");

			var user = ProviderManager.AddProvider(context, email, password, name, CNPJ);

			CurrentUser = user;
			IsProvider = true;
		}
	}
}
