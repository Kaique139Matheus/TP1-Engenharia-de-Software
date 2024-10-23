using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Models
{
	[Index(nameof(CPF), IsUnique = true)]
	public class ClientModel : UserModel
	{
        public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string CPF { get; set; } = null!;

		public List<ReviewModel> Reviews { get; set; } = null!;
		public List<BookingModel> Bookings { get; set; } = null!;
    }
}
