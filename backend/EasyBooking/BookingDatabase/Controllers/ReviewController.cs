using BookingDatabase.Data;
using BookingDatabase.Models;
using BookingDatabase.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

[Route("reviews")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly EasyBookingContext _context;

    public ReviewsController(EasyBookingContext context)
    {
        _context = context;
    }

    // POST: reviews
    [HttpPost]
    public ActionResult<ReviewModel> PostReview([FromBody] ReviewModel reviewModel)
    {
        try
        {
            var newReview = ReviewManager.AddReview(_context, reviewModel.ClientID, reviewModel.ProviderID, reviewModel.Score, reviewModel.Comment);
            Console.WriteLine($"Review added: {newReview.ClientID} {newReview.ProviderID} {newReview.Score} {newReview.Comment}");
            return CreatedAtAction(nameof(GetProviderReviews), new { providerID = newReview.ProviderID }, newReview);
        }
        catch (DbUpdateException ex)
        {
            var innerException = ex.InnerException?.Message;
            Console.WriteLine($"Error: {innerException}");
            return BadRequest(innerException);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    // GET: reviews/provider/{providerID}
    [HttpGet("provider/{providerID}")]
    public ActionResult<IEnumerable<ReviewModel>> GetProviderReviews(int providerID)
    {
        try
        {
            var reviews = ReviewManager.GetProviderReviews(_context, providerID);
            return Ok(reviews);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //// PUT: reviews/{reviewID}
    //[HttpPut("{reviewID}")]
    //public ActionResult<ReviewModel> PutReview(int reviewID, [FromBody] ReviewUpdateModel reviewUpdateModel)
    //{
    //    try
    //    {
    //        var updatedReview = ReviewManager.UpdateReview(_context, reviewID, reviewUpdateModel.Score, reviewUpdateModel.Comment);
    //        return Ok(updatedReview);
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}

    //// DELETE: reviews/{reviewID}
    //[HttpDelete("{reviewID}")]
    //public IActionResult DeleteReview(int reviewID, [FromBody] ReviewDeleteModel reviewDeleteModel)
    //{
    //    try
    //    {
    //        ReviewManager.RemoveReview(_context, reviewID, reviewDeleteModel.ServiceID, reviewDeleteModel.ProviderID);
    //        return NoContent();
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}
}

public class ReviewUpdateModel
{
    public int Score { get; set; }
    public string? Comment { get; set; }
}

public class ReviewDeleteModel
{
    public int ServiceID { get; set; }
    public int ProviderID { get; set; }
}
