using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.DTO
{
	public class ReviewDTO
	{
		public int ClientID { get; set; }
		public int ProviderID { get; set; }
		public string ClientFirstName { get; set; } = "";
		public string ClientLastName { get; set; } = "";
		public int Score { get; set; }
		public string? Comment { get; set; }
	}
}
