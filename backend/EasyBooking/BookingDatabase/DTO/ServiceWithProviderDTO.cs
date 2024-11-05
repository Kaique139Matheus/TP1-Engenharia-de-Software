using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.DTO
{
	public class ServiceWithProviderDTO
	{
		public int ServiceID { get; set; }
		public string ServiceName { get; set; }
		public string ServiceDescription { get; set; }
		public decimal ServicePrice { get; set; }
		public int ServiceDurationInMinutes { get; set; }
		public int ProviderID { get; set; }
		public string ProviderName { get; set; } 
		public string ProviderCNPJ { get; set; }
	}
}
