using BookingDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Data
{
	public class EasyBookingContext : DbContext
	{
		public DbSet<ProviderModel> Providers { get; set; }
		public DbSet<ServiceModel> Services { get; set; }
		public DbSet<TimeslotModel> Timeslots { get; set; }
		public DbSet<BookingModel> Bookings { get; set; }
		public DbSet<ClientModel> Clients { get; set; }
		public DbSet<ReviewModel> Reviews { get; set; }

		public string DbPath { get; private set; }

		public EasyBookingContext()
		{
			var folder = Environment.SpecialFolder.LocalApplicationData;
			var path = Environment.GetFolderPath(folder);
			DbPath = System.IO.Path.Join(path, "easybooking.db");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		=> options.UseSqlite($"Data Source={DbPath}");
	}
}
