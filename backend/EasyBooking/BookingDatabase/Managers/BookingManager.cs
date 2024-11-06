using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingDatabase.Data;
using BookingDatabase.DTO;
using BookingDatabase.Models;
using BookingDatabase.Services;

namespace BookingDatabase.Managers
{
    public class BookingManager
    {
        public static BookingModel AddBooking(EasyBookingContext context, int providerID, int serviceID, int timeslotID, DateOnly date, int? clientID)
        {
            var booking = new BookingModel
            {
                ProviderID = providerID,
                ServiceID = serviceID,
                TimeslotID = timeslotID,
                Date = date,
                ClientID = clientID
            };

            context.Bookings.Add(booking);
            context.SaveChanges();

            return booking;
        }

		public static void VerifyAndAddBookingsUntilMaxDate(EasyBookingContext context, ServiceModel service, DateOnly maxDate)
		{
			var timeslots = context.Timeslots.Where(t => t.ServiceID == service.ID).ToList();

			var bookingsToAdd = new List<BookingModel>();
			var tomorrow = DateOnly.FromDateTime(DateTime.Now).AddDays(1);
			foreach (var timeslot in timeslots)
			{
				for (DateOnly date = tomorrow; date <= maxDate; date = date.AddDays(1))
				{
					var booking = context.Bookings.Where(b => b.ServiceID == service.ID && b.TimeslotID == timeslot.ID && b.Date == date).FirstOrDefault();
					if (booking == null)
					{
						bookingsToAdd.Add(new BookingModel
						{
							ProviderID = service.ProviderID,
							ServiceID = service.ID,
							TimeslotID = timeslot.ID,
							Date = date,
							ClientID = null
						});
					}
				}
			}

			context.Bookings.AddRange(bookingsToAdd);
			context.SaveChanges();
		}

		public static bool VerifyBookingAvailability(EasyBookingContext context, int serviceID, DateOnly date)
		{
			var service = context.Services.Find(serviceID);
			if (service == null) throw new Exception("Service not found");
			var timeslots = context.Timeslots.Where(t => t.ServiceID == serviceID).ToList();
			foreach (var timeslot in timeslots)
			{
				var booking = context.Bookings.Where(b => b.ServiceID == serviceID && b.TimeslotID == timeslot.ID && b.Date == date).FirstOrDefault();
				if (booking == null || booking.ClientID == null) return true;
			}
			return false;
		}

		//Pegar os bookings de cada serviço
		public static List<BookingModel> GetServiceBookings(EasyBookingContext context, int serviceID)
        {
            if (context.Services.Find(serviceID) == null) throw new Exception("Service not found");
            var bookings = context.Bookings.Where(t => t.ServiceID == serviceID).ToList();

            return bookings;
        }

		public static List<BookingModel> GetBookingsUntilMaxDate(EasyBookingContext context, int serviceID)
		{
			var service = context.Services.Find(serviceID);
			if (service == null) throw new Exception("Service not found");
			var today = DateOnly.FromDateTime(DateTime.Now);
			var maxDaysInAdvance = 30;
			var maxDate = today.AddDays(maxDaysInAdvance);

			VerifyAndAddBookingsUntilMaxDate(context, service, maxDate);

			var bookings = context.Bookings.Where(b => b.ServiceID == serviceID && b.Date <= maxDate).ToList();

			return bookings;
		}

		public static List<BookingWithTime> GetBookingsWithTimeFromServiceAndDate(EasyBookingContext context, int serviceID, DateOnly date)
		{
			var service = context.Services.Find(serviceID);
			if (service == null) throw new Exception("Service not found");
			var timeslots = context.Timeslots.Where(t => t.ServiceID == serviceID).ToList();
			foreach (var timeslot in timeslots)
			{
				var booking = context.Bookings.Where(b => b.ServiceID == serviceID && b.TimeslotID == timeslot.ID && b.Date == date).FirstOrDefault();
				if (booking == null)
				{
					context.Bookings.Add(new BookingModel
					{
						ProviderID = service.ProviderID,
						ServiceID = service.ID,
						TimeslotID = timeslot.ID,
						Date = date,
						ClientID = null
					});
				}
			}
			context.SaveChanges();

			var bookingsWithTime = context.Bookings
				.Where(b => b.ServiceID == serviceID && b.Date == date)
				.Join(context.Timeslots,
					  booking => booking.TimeslotID,
					  timeslot => timeslot.ID,
					  (booking, timeslot) => new BookingWithTime
					  {
						  ProviderID = booking.ProviderID,
						  ServiceID = booking.ServiceID,
						  TimeslotID = booking.TimeslotID,
						  Date = booking.Date,
						  ClientID = booking.ClientID,
						  Time = timeslot.Time
					  })
				.ToList();

			return bookingsWithTime;
		}


		//Pegar os bookings de cada cliente --> provável caso de uso
		public static List<ClientBookingDTO> GetClientBookingsDTO(EasyBookingContext context, int clientID)
		{
			if (context.Clients.Find(clientID) == null) throw new Exception("Client not found");

			var today = DateOnly.FromDateTime(DateTime.Now);

			var bookingsDTO = context.Bookings
				.Where(b => b.ClientID == clientID)
				.Join(context.Services,
					  booking => booking.ServiceID,
					  service => service.ID,
					  (booking, service) => new { booking, service })
				.Join(context.Providers,
					  bs => bs.service.ProviderID,
					  provider => provider.ID,
					  (bs, provider) => new { bs.booking, bs.service, provider })
				.Join(context.Timeslots,
					  bsp => bsp.booking.TimeslotID,
					  timeslot => timeslot.ID,
					  (bsp, timeslot) => new ClientBookingDTO
					  {
						  ProviderID = bsp.booking.ProviderID,
						  ServiceID = bsp.booking.ServiceID,
						  TimeslotID = bsp.booking.TimeslotID,
						  ServiceName = bsp.service.Name,
						  ProviderName = bsp.provider.Name,
						  Time = timeslot.Time,
						  Date = bsp.booking.Date
					  })
				.ToList();

			return bookingsDTO;
		}

        public static BookingModel ValidateAndGetTimeslotBooking(EasyBookingContext context, int serviceID, int providerID, int timeslotID)
        {
            ServiceManager.ValidateAndGetProviderService(context, serviceID, providerID);

            var booking = context.Bookings.Find(timeslotID);
            if (booking == null) throw new Exception("booking not found");
            if (booking.ServiceID != serviceID) throw new Exception("booking does not belong to service");

            return booking;
        }

        public static BookingModel UpdateBooking(EasyBookingContext context, int providerID, int serviceID, int timeslotID, DateOnly date, int? clientID)
        {
            //var booking = ValidateAndGetTimeslotBooking(context, serviceID, providerID, timeslotID);
			if (context.Services.Find(serviceID) == null) throw new Exception("Service not found");
			if (context.Providers.Find(providerID) == null) throw new Exception("Provider not found");
			if (context.Timeslots.Find(timeslotID) == null) throw new Exception("Timeslot not found");

			var booking = context.Bookings.Find(providerID, serviceID, timeslotID, date);
			if (booking == null) throw new Exception("Booking not found");

			if (clientID == null || clientID < 0) booking.ClientID = null;
			else booking.ClientID = clientID;

            context.SaveChanges();

            return booking;
        }

        public static void RemoveBooking(EasyBookingContext context, int serviceID, int providerID, int timeslotID)
        {
            var booking = ValidateAndGetTimeslotBooking(context, serviceID, providerID, timeslotID);

            context.Bookings.Remove(booking);
            context.SaveChanges();
        }
    }
}