using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Models
{
	//[PrimaryKey("ID", "ProviderID", "ServiceID")]
	public class TimeslotModel
	{
        public int ID { get; set; }
        public int ProviderID { get; set; }
        public int ServiceID { get; set; }
        public int Time { get; set; }

		public ServiceModel Service { get; set; } = null!;
		public ProviderModel Provider { get; set; } = null!;
	}
}
