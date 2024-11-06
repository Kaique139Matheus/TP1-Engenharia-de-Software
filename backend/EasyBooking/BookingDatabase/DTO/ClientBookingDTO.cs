using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.DTO
{
	public class ClientBookingDTO
	{
		public int ProviderID { get; set; }
		public int ServiceID { get; set; }
		public int TimeslotID { get; set; }
		public string ServiceName { get; set; } = "";
		public string ProviderName { get; set; } = "";
		public int Time { get; set; }
		public DateOnly Date { get; set; }
	}
}
