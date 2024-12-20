﻿using BookingDatabase.Data;
using BookingDatabase.DTO;
using BookingDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabase.Services
{
	public static class ServiceManager
	{
		public static ServiceModel AddService(EasyBookingContext context, int providerID, string name, string description, decimal price, int durationInMinutes)
		{
			if (!AuthenticationManager.Instance.IsUserLoggedIn(providerID)) throw new Exception("User not logged in");

			var provider = context.Providers.Find(providerID);
			if (provider == null) throw new Exception("Provider not found");

			var service = new ServiceModel
			{
				Name = name,
				Description = description,
				Price = price,
				DurationInMinutes = durationInMinutes,
				ProviderID = providerID,
			};

			context.Services.Add(service);
			context.SaveChanges();

			return service;
		}

		public static List<ServiceWithProviderDTO> GetAllServicesWithProviders(EasyBookingContext context)
		{
			return context.Services
				.Join(context.Providers,
					  service => service.ProviderID,
					  provider => provider.ID,
					  (service, provider) => new ServiceWithProviderDTO
					  {
						  ServiceID = service.ID,
						  ServiceName = service.Name,
						  ServiceDescription = service.Description,
						  ServicePrice = service.Price,
						  ServiceDurationInMinutes = service.DurationInMinutes,
						  ProviderID = provider.ID,
						  ProviderName = provider.Name,
						  ProviderCNPJ = provider.CNPJ
					  })
				.ToList();
		}

		public static List<ServiceModel> GetProviderServices(EasyBookingContext context, int providerID)
		{
			if (context.Providers.Find(providerID) == null) throw new Exception("Provider not found");
			var services = context.Services.Where(s => s.ProviderID == providerID).ToList();

			return services;
		}

		/// <summary>
		/// Verifies that the service belongs to the provider if it exists
		/// </summary>
		/// <returns>The service if it exists and belongs to the provider</returns>
		public static ServiceModel ValidateAndGetProviderService(EasyBookingContext context, int providerID, int serviceID)
		{
			if (!AuthenticationManager.Instance.IsUserLoggedIn(providerID)) throw new Exception("User not logged in");

			var service = context.Services.Find(serviceID);
			if (service == null) throw new Exception("Service not found");
			if (service.ProviderID != providerID) throw new Exception("Service does not belong to provider");

			return service;
		}

		public static ServiceModel UpdateService(EasyBookingContext context, int providerId, int serviceID, string? newName = null, string? newDescription = null, decimal? newPrice = null)
		{
			var serviceToUpdate = ValidateAndGetProviderService(context, providerId, serviceID);

			if (newName != null) serviceToUpdate.Name = newName;
			if (newDescription != null) serviceToUpdate.Description = newDescription;
			if (newPrice != null) serviceToUpdate.Price = newPrice.Value;

			context.SaveChanges();

			return serviceToUpdate;
		}

		public static void RemoveService(EasyBookingContext context, int providerID, int serviceID)
		{
			var serviceToRemove = ValidateAndGetProviderService(context, providerID, serviceID);

			context.Services.Remove(serviceToRemove);
			context.SaveChanges();
		}
	}
}
