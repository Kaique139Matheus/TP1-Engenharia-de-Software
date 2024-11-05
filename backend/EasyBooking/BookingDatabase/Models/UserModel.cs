using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Models
{
	[Index(nameof(Email), IsUnique = true)]
	public class UserModel
	{
		public int ID { get; set; }
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
	}
}
