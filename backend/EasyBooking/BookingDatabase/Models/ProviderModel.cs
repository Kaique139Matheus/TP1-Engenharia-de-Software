using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Models
{
	[Index(nameof(Name), IsUnique = true)]
	[Index(nameof(CNPJ), IsUnique = true)]
	public class ProviderModel : UserModel
	{
        public string Name { get; set; } = null!;
		public string CNPJ { get; set; } = null!;

		public List<ServiceModel> Services { get; set; } = new List<ServiceModel>();
		public List<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();
	}
}
