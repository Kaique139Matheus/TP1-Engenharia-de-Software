using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingDatabase.Data;
using BookingDatabase.Models;

namespace BookingDatabase.Services
{
    public class ReviewManager
    {
        public static ReviewModel AddReview(EasyBookingContext context, int clientId, int providerID, int score, string? comment)
        {
            // Verifique se o cliente existe
            var client = context.Clients.Find(clientId);
            if (client == null) throw new Exception("Client not found");

            // Verifique se o provedor existe
            var provider = context.Providers.Find(providerID);
            if (provider == null) throw new Exception("Provider not found");

            // Verifique se já existe um review para esse cliente e provedor no contexto
            if (context.Reviews.Any(r => r.ClientID == clientId && r.ProviderID == providerID))
            {
                throw new Exception("Review already exists for this client and provider.");
            }

            var review = new ReviewModel
            {
                ClientID = clientId,
                ProviderID = providerID,
                Score = score,
                Comment = comment,
                Client = client, // Associando ao cliente existente
                Provider = provider // Associando ao provedor existente
            };

            context.Reviews.Add(review);
            context.SaveChanges();

            return review;
        }



        public static List<ReviewModel> GetProviderReviews(EasyBookingContext context, int providerID)
        {
            var provider = context.Providers.Find(providerID);
            if (provider == null) throw new Exception("Provider does not exist");
            var reviews = provider.Reviews;

            return provider.Reviews;
        }

        public static ReviewModel ValidateAndGetServiceReview(EasyBookingContext context, int id, int serviceID, int providerID)
        {

            var review = context.Reviews.Find(id);
            if (review == null) throw new Exception("Review not found");
            if (review.ProviderID != providerID) throw new Exception("Review does not belong to service");

            return review;
        }

        public static ReviewModel UpdateReview(EasyBookingContext context, int id, int score, string? comment)
        {
            var review = context.Reviews.Find();
            if (review == null) throw new Exception("Review not found");

            review.Score = score;
            review.Comment = comment;

            context.SaveChanges();

            return review;
        }

        public static void RemoveReview(EasyBookingContext context, int id, int serviceID, int providerID)
        {
            var review = ValidateAndGetServiceReview(context, id, serviceID, providerID);

            context.Reviews.Remove(review);
            context.SaveChanges();
        }
    }
}