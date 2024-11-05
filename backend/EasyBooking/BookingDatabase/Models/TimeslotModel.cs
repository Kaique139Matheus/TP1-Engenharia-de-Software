using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Models
{
	public class TimeslotModel
	{
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public int Time { get; set; }

		public List<BookingModel> Bookings { get; set; } = new List<BookingModel>();
	}
}
