using BookingDatabase.Data;
using BookingDatabase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookingDatabase.Tests
{
	[Collection("Database collection")]
	public class ReviewManagerTests
	{
		private readonly EasyBookingContext context;

		public ReviewManagerTests()
		{
			EasyBookingContext.TestDatabase = true;
			context = new EasyBookingContext();

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}

		[Fact]
		public void AddReview_ShouldAddReview()
		{
			// Arrange
			var testClient = TestObjects.TestClient;
			var testProvider = TestObjects.TestProvider;
			var testReview = TestObjects.TestReview;
			context.Clients.Add(testClient);
			context.Providers.Add(testProvider);
			context.SaveChanges();

			// Act
			var review = ReviewManager.AddReview(context, testClient.ID, testProvider.ID, testReview.Score, testReview.Comment);

			// Assert
			Assert.Equal(testClient.ID, review.ClientID);
			Assert.Equal(testProvider.ID, review.ProviderID);
			Assert.Equal(testReview.Score, review.Score);
			Assert.Equal(testReview.Comment, review.Comment);
		}

		[Fact]
		public void UpdateReview_ShouldUpdateReview()
		{
			// Arrange
			var testClient = TestObjects.TestClient;
			var testProvider = TestObjects.TestProvider;
			var testReview = TestObjects.TestReview;
			context.Clients.Add(testClient);
			context.Providers.Add(testProvider);
			context.Reviews.Add(testReview);
			context.SaveChanges();

			// Act
			var updatedReview = ReviewManager.UpdateReview(context, testClient.ID, testProvider.ID, 5, "Updated comment");

			// Assert
			Assert.Equal(5, updatedReview.Score);
			Assert.Equal("Updated comment", updatedReview.Comment);
		}

		[Fact]
		public void RemoveReview_ShouldRemoveReview()
		{
			// Arrange
			var testClient = TestObjects.TestClient;
			var testProvider = TestObjects.TestProvider;
			var testReview = TestObjects.TestReview;
			context.Clients.Add(testClient);
			context.Providers.Add(testProvider);
			context.Reviews.Add(testReview);
			context.SaveChanges();

			// Act
			ReviewManager.RemoveReview(context, testClient.ID, testProvider.ID);

			// Assert
			Assert.Empty(context.Reviews);
		}

		[Fact]
		public void GetProviderReviews_ShouldReturnReviews()
		{
			// Arrange
			var testClient = TestObjects.TestClient;
			var testClient2 = TestObjects.TestClient2;
			context.Clients.Add(testClient);
			context.Clients.Add(testClient2);

			var testProvider = TestObjects.TestProvider;
			context.Providers.Add(testProvider);

			context.SaveChanges();

			var testReview = TestObjects.TestReview;
			var testReview2 = TestObjects.TestReview2;
			testReview2.ClientID = testClient2.ID; // Precisa salvar as mudanças para atualizar o ID do testClient2
			context.Reviews.Add(testReview);
			context.Reviews.Add(testReview2);

			context.SaveChanges();

			// Act
			var reviews = ReviewManager.GetProviderReviews(context, testProvider.ID);

			// Assert
			Assert.True(reviews.Count == 2);
			Assert.Contains(reviews, r => r.ClientID == testClient.ID);
			Assert.Contains(reviews, r => r.ClientID == testClient2.ID);
		}
	}
}
