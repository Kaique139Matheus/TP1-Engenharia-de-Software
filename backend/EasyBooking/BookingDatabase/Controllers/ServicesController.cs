using BookingDatabase.Data;
using BookingDatabase.Models;
using BookingDatabase.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("[controller]")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly EasyBookingContext _context;

    public ServicesController(EasyBookingContext context)
    {
        _context = context;
    }

    // GET: services/getAll
    [HttpGet("getAll")]
    public ActionResult<IEnumerable<ServiceModel>> GetAllServicesWithProviders()
    {
        try
        {
            var servicesWithProviders = ServiceManager.GetAllServicesWithProviders(_context);
            return Ok(servicesWithProviders);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET: services/provider/{providerID}
    [HttpGet("provider/{providerID}")]
    public ActionResult<IEnumerable<ServiceModel>> GetProviderServices(int providerID)
    {
        try
        {
            var services = ServiceManager.GetProviderServices(_context, providerID);
            return Ok(services);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // POST: services
    [HttpPost]
    public ActionResult<ServiceModel> PostService([FromBody] ServiceModel serviceModel)
    {
        try
        {
            var newService = ServiceManager.AddService(_context, serviceModel.ProviderID, serviceModel.Name, serviceModel.Description, serviceModel.Price, serviceModel.DurationInMinutes);
            return CreatedAtAction(nameof(GetProviderServices), new { providerID = serviceModel.ProviderID }, newService);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: services/{serviceID}
    [HttpPut("{serviceID}")]
    public ActionResult<ServiceModel> PutService(int serviceID, [FromBody] ServiceUpdateModel serviceUpdateModel)
    {
        try
        {
            var updatedService = ServiceManager.UpdateService(_context, serviceUpdateModel.ProviderID, serviceID, serviceUpdateModel.Name, serviceUpdateModel.Description, serviceUpdateModel.Price);
            return Ok(updatedService);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: services/{serviceID}
    [HttpDelete("{serviceID}")]
    public IActionResult DeleteService([FromRoute] int serviceID)
    {
        try
        {
            ServiceManager.RemoveService(_context, serviceID);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

public class ServiceUpdateModel
{
    public int ProviderID { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}
