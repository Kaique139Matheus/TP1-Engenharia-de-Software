using BookingDatabase.Data;
using BookingDatabase.Models;
using BookingDatabase.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BookingDatabase.DTO;

[Route("[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly EasyBookingContext _context;

    public BookingsController(EasyBookingContext context)
    {
        _context = context;
    }

    // POST: bookings
    [HttpPost]
    public ActionResult<BookingModel> PostBooking([FromBody] BookingModel bookingModel)
	{
		try
		{
			Console.WriteLine("BookingModel: " + bookingModel);
			var newBooking = BookingManager.AddBooking(_context, bookingModel.ProviderID, bookingModel.ServiceID, bookingModel.TimeslotID, bookingModel.Date, bookingModel.ClientID);
			return Ok(newBooking);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	// GET: bookings/service/{serviceID}
	[HttpGet("service/{serviceID}")]
    public ActionResult<IEnumerable<BookingModel>> GetServiceBookings(int serviceID)
    {
        try
        {
            var bookings = BookingManager.GetServiceBookings(_context, serviceID);
            return Ok(bookings);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

	// GET: bookings/service/{serviceID}
	[HttpGet("service/{serviceID}/bookingsUntilMaxDate")]
	public ActionResult<IEnumerable<BookingModel>> GetBookingsUntilMaxDate(int serviceID)
	{
		try
		{
			var bookings = BookingManager.GetBookingsUntilMaxDate(_context, serviceID);
			return Ok(bookings);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	// GET: bookings/service/{serviceID}/{dateTime}
	[HttpGet("service/{serviceID}/{dateTime}")]
	public ActionResult<IEnumerable<BookingWithTime>> GetBookingsWithTimeFromServiceAndDate(int serviceID, DateTime dateTime)
	{
		try
		{
			var date = DateOnly.FromDateTime(dateTime);
			var bookingsWithTime = BookingManager.GetBookingsWithTimeFromServiceAndDate(_context, serviceID, date);
			return Ok(bookingsWithTime);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	// GET: bookings/availability/{serviceID}/{dateTime}
	[HttpGet("availability/{serviceID}/{dateTime}")]
	public ActionResult<bool> VerifyBookingAvailability(int serviceID, DateTime dateTime)
	{
		try
		{
			var date = DateOnly.FromDateTime(dateTime);
			var isAvailable = BookingManager.VerifyBookingAvailability(_context, serviceID, date);
			return Ok(isAvailable);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	// GET: bookings/client/{clientID}
	[HttpGet("client/{clientID}")]
    public ActionResult<IEnumerable<BookingModel>> GetClientBookingsDTO(int clientID)
    {
        try
        {
            var bookings = BookingManager.GetClientBookingsDTO(_context, clientID);
            return Ok(bookings);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

	// PUT: bookings/update/providerID/serviceID/timeslotID/dateTime/clientID
	[HttpPut("update/{providerID}/{serviceID}/{timeslotID}/{dateTime}/{clientID}")]
	public ActionResult<BookingModel> PutBooking(int providerID, int serviceID, int timeslotID, DateTime dateTime, int? clientID)
	{
        try
        {
			var date = DateOnly.FromDateTime(dateTime);
			var updatedBooking = BookingManager.UpdateBooking(_context, providerID, serviceID, timeslotID, date, clientID);
			return Ok(updatedBooking);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: bookings/{timeslotID}
    [HttpDelete("{timeslotID}")]
    public IActionResult DeleteBooking(int timeslotID, [FromBody] BookingDeleteModel bookingDeleteModel)
    {
        try
        {
            BookingManager.RemoveBooking(_context, bookingDeleteModel.ServiceID, bookingDeleteModel.ProviderID, timeslotID);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

public class BookingUpdateModel
{
	public int TimeslotID { get; set; }
	public int ServiceID { get; set; }
    public int ProviderID { get; set; }
    public int ClientID { get; set; }
	public DateTime Date { get; set; }
}

public class BookingDeleteModel
{
    public int ServiceID { get; set; }
    public int ProviderID { get; set; }
}
