using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Models
{
	//[PrimaryKey("ID", "ProviderID")]
	[Index(nameof(ProviderID), nameof(Name), IsUnique = true)]
	public class ServiceModel
	{
        public int ID { get; set; }
        public int ProviderID { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		[Column(TypeName = "decimal(6, 2)")] public decimal Price { get; set; }
		public int DurationInMinutes { get; set; }

		public ProviderModel Provider { get; set; } = null!;
    }
}
