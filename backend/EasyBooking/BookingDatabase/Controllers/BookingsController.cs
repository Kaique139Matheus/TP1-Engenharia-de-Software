using BookingDatabase.Data;
using BookingDatabase.Models;
using BookingDatabase.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            var newBooking = BookingManager.AddBooking(_context, bookingModel.ProviderID, bookingModel.ServiceID, bookingModel.TimeslotID, bookingModel.Date, bookingModel.ClientID);
            return CreatedAtAction(nameof(GetServiceBookings), new { serviceID = bookingModel.ServiceID }, newBooking);
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

    // GET: bookings/client/{clientID}
    [HttpGet("client/{clientID}")]
    public ActionResult<IEnumerable<BookingModel>> GetClientBookings(int clientID)
    {
        try
        {
            var bookings = BookingManager.GetClientBookings(_context, clientID);
            return Ok(bookings);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: bookings/{timeslotID}
    [HttpPut("{timeslotID}")]
    public ActionResult<BookingModel> PutBooking(int timeslotID, [FromBody] BookingUpdateModel bookingUpdateModel)
    {
        try
        {
            var updatedBooking = BookingManager.UpdateBooking(_context, bookingUpdateModel.ServiceID, bookingUpdateModel.ProviderID, timeslotID, bookingUpdateModel.Date);
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
    public int ServiceID { get; set; }
    public int ProviderID { get; set; }
    public DateOnly Date { get; set; }
}

public class BookingDeleteModel
{
    public int ServiceID { get; set; }
    public int ProviderID { get; set; }
}
