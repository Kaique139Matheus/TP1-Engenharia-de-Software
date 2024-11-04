using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Models
{
	[PrimaryKey("ClientID", "ProviderID")]
	public class ReviewModel
	{
		public int ClientID { get; set; }
		public int ProviderID { get; set; }
		public int Score { get; set; }
		public string? Comment { get; set; }

		public ClientModel? Client { get; set; } // Permitindo valor nulo
		public ProviderModel? Provider { get; set; } // Permitindo valor nulo
	}


}
