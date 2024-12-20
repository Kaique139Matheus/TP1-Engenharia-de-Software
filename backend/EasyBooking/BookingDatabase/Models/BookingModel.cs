﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Models
{
	[PrimaryKey("ProviderID", "ServiceID", "TimeslotID", "Date")]
	public class BookingModel
	{
		public int ProviderID { get; set; }
		public int ServiceID { get; set; }
		public int TimeslotID { get; set; }
		public DateOnly Date { get; set; }
		public int? ClientID { get; set; }
	}
}
