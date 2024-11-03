using BookingDatabase.Data;
using BookingDatabase.Models;
using BookingDatabase.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly EasyBookingContext _context;

    public ClientsController(EasyBookingContext context)
    {
        _context = context;
    }

    // GET: api/clients
    [HttpGet]
    public ActionResult<IEnumerable<ClientModel>> GetClients()
    {
        return _context.Clients.ToList();
    }

    // GET: api/clients/5
    [HttpGet("{id}")]
    public ActionResult<ClientModel> GetClient(int id)
    {
        var client = _context.Clients.Find(id);
        if (client == null)
        {
            return NotFound();
        }
        return client;
    }

    // POST: api/clients
    [HttpPost]
    public ActionResult<ClientModel> PostClient(ClientModel client)
    {
        var newClient = ClientManager.AddClient(_context, client.Email, client.Password, client.CPF, client.FirstName, client.LastName);
        return CreatedAtAction(nameof(GetClient), new { id = newClient.ID }, newClient);
    }

    // PUT: api/clients/5
    [HttpPut("{id}")]
    public IActionResult PutClient(int id, [FromBody] string newPassword)
    {
        try
        {
            var updatedClient = ClientManager.UpdateClient(_context, id, newPassword);
            return Ok(updatedClient);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/clients/5
    [HttpDelete("{id}")]
    public IActionResult DeleteClient(int id)
    {
        try
        {
            ClientManager.RemoveClient(_context, id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
