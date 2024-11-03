using BookingDatabase.Data;
using BookingDatabase.Models;
using BookingDatabase.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("[controller]")]
[ApiController]
public class ProvidersController : ControllerBase
{
    private readonly EasyBookingContext _context;

    public ProvidersController(EasyBookingContext context)
    {
        _context = context;
    }

    // GET: api/providers
    [HttpGet]
    public ActionResult<IEnumerable<ProviderModel>> GetProviders()
    {
        return _context.Providers.ToList();
    }

    // GET: api/providers/5
    [HttpGet("{id}")]
    public ActionResult<ProviderModel> GetProvider(int id)
    {
        var provider = _context.Providers.Find(id);
        if (provider == null)
        {
            return NotFound();
        }
        return provider;
    }

    // POST: api/providers
    [HttpPost]
    public ActionResult<ProviderModel> PostProvider(ProviderModel provider)
    {
        try
        {
            var newProvider = ProviderManager.AddProvider(_context, provider.Email, provider.Password, provider.Name, provider.CNPJ);
            return CreatedAtAction(nameof(GetProvider), new { id = newProvider.ID }, newProvider);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/providers/5
    [HttpPut("{id}")]
    public IActionResult PutProvider(int id, [FromBody] string newPassword)
    {
        try
        {
            var updatedProvider = ProviderManager.UpdateProvider(_context, id, newPassword);
            return Ok(updatedProvider);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/providers/5
    [HttpDelete("{id}")]
    public IActionResult DeleteProvider(int id)
    {
        try
        {
            ProviderManager.DeleteProvider(_context, id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
