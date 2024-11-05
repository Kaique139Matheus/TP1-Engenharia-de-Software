using BookingDatabase.Data;
using BookingDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Services
{
	public static class TimeslotManager
	{
		public static TimeslotModel AddTimeslot(EasyBookingContext context, int serviceID, int time)
		{
			var service = context.Services.Find(serviceID);
			if (service == null) throw new Exception("Service not found");

			var timeslot = new TimeslotModel
			{
				ServiceID = serviceID,
				Time = time
			};

			context.Timeslots.Add(timeslot);
			context.SaveChanges();

			return timeslot;
		}

		public static List<TimeslotModel> GetServiceTimeslots(EasyBookingContext context, int serviceID)
		{
			if (context.Services.Find(serviceID) == null) throw new Exception("Service not found");
			var timeslots = context.Timeslots.Where(t => t.ServiceID == serviceID).ToList();

			return timeslots;
		}

		public static TimeslotModel ValidateAndGetServiceTimeslot(EasyBookingContext context, int id, int serviceID, int providerID)
		{
			ServiceManager.ValidateAndGetProviderService(context, serviceID, providerID);

			var timeslot = context.Timeslots.Find(id);
			if (timeslot == null) throw new Exception("Timeslot not found");
			if (timeslot.ServiceID != serviceID) throw new Exception("Timeslot does not belong to service");

			return timeslot;
		}

		public static TimeslotModel UpdateTimeslot(EasyBookingContext context, int id, int serviceID, int providerID, int time)
		{
			var timeslot = ValidateAndGetServiceTimeslot(context, id, serviceID, providerID);

			timeslot.Time = time;

			context.SaveChanges();

			return timeslot;
		}

		public static void RemoveTimeslot(EasyBookingContext context, int id, int serviceID, int providerID)
		{
			var timeslot = ValidateAndGetServiceTimeslot(context, id, serviceID, providerID);

			context.Timeslots.Remove(timeslot);
			context.SaveChanges();
		}
	}
}
