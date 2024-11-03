using BookingDatabase.Data;
using BookingDatabase.Models;
using BookingDatabase.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class TimeslotsController : ControllerBase
{
    private readonly EasyBookingContext _context;

    public TimeslotsController(EasyBookingContext context)
    {
        _context = context;
    }

    // GET: api/timeslots/service/{serviceID}
    [HttpGet("service/{serviceID}")]
    public ActionResult<IEnumerable<TimeslotModel>> GetServiceTimeslots(int serviceID)
    {
        try
        {
            var timeslots = TimeslotManager.GetServiceTimeslots(_context, serviceID);
            return Ok(timeslots);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // POST: api/timeslots
    [HttpPost]
    public ActionResult<TimeslotModel> PostTimeslot([FromBody] TimeslotModel timeslotModel)
    {
        try
        {
            var newTimeslot = TimeslotManager.AddTimeslot(_context, timeslotModel.ServiceID, timeslotModel.Time);
            return CreatedAtAction(nameof(GetServiceTimeslots), new { serviceID = timeslotModel.ServiceID }, newTimeslot);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/timeslots/{timeslotID}
    [HttpPut("{timeslotID}")]
    public ActionResult<TimeslotModel> PutTimeslot(int timeslotID, [FromBody] TimeslotUpdateModel timeslotUpdateModel)
    {
        try
        {
            var updatedTimeslot = TimeslotManager.UpdateTimeslot(_context, timeslotID, timeslotUpdateModel.ServiceID, timeslotUpdateModel.ProviderID, timeslotUpdateModel.Time);
            return Ok(updatedTimeslot);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/timeslots/{timeslotID}
    [HttpDelete("{timeslotID}")]
    public IActionResult DeleteTimeslot(int timeslotID, [FromBody] TimeslotDeleteModel timeslotDeleteModel)
    {
        try
        {
            TimeslotManager.RemoveTimeslot(_context, timeslotID, timeslotDeleteModel.ServiceID, timeslotDeleteModel.ProviderID);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

public class TimeslotUpdateModel
{
    public int ServiceID { get; set; }
    public int ProviderID { get; set; }
    public int Time { get; set; }
}

public class TimeslotDeleteModel
{
    public int ServiceID { get; set; }
    public int ProviderID { get; set; }
}
