using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.DTO
{
	public class BookingWithTime
	{
		public int ProviderID { get; set; }
		public int ServiceID { get; set; }
		public int TimeslotID { get; set; }
		public DateOnly Date { get; set; }
		public int? ClientID { get; set; }
		public int Time { get; set; }
	}
}
