using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingDatabase.Data;
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

        //Pegar os bookings de cada serviço
        public static List<BookingModel> GetServiceBookings(EasyBookingContext context, int serviceID)
        {
            if (context.Services.Find(serviceID) == null) throw new Exception("Service not found");
            var bookings = context.Bookings.Where(t => t.ServiceID == serviceID).ToList();

            return bookings;
        }


        //Pegar os bookings de cada cliente --> provável caso de uso
        public static List<BookingModel> GetClientBookings(EasyBookingContext context, int clientID)
        {
            if (context.Clients.Find(clientID) == null) throw new Exception("Service not found");
            var bookings = context.Bookings.Where(t => t.ClientID == clientID).ToList();

            return bookings;
        }

        public static BookingModel ValidateAndGetTimeslotBooking(EasyBookingContext context, int serviceID, int providerID, int timeslotID)
        {
            ServiceManager.ValidateAndGetProviderService(context, serviceID, providerID);

            var booking = context.Bookings.Find(timeslotID);
            if (booking == null) throw new Exception("booking not found");
            if (booking.ServiceID != serviceID) throw new Exception("booking does not belong to service");

            return booking;
        }

        public static BookingModel UpdateBooking(EasyBookingContext context, int serviceID, int providerID, int timeslotID, int clientID)
        {
            var booking = ValidateAndGetTimeslotBooking(context, serviceID, providerID, timeslotID);

            booking.ClientID = clientID;

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