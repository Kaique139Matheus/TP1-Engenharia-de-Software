using BookingDatabase.Data;
using BookingDatabase.Models;
using BookingDatabase.Services;
using Microsoft.AspNetCore.Mvc;
using System;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly EasyBookingContext _context;

    public AuthController(EasyBookingContext context)
    {
        _context = context;
    }

    // POST: api/auth/login
    [HttpPost("login")]
    public IActionResult Login([FromBody] UserModel loginModel)
    {
        try
        {
            AuthenticationManager.Instance.Login(_context, loginModel.Email, loginModel.Password);
            return Ok("Login successful");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // POST: api/auth/logout
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        AuthenticationManager.Instance.Logout();
        return Ok("Logout successful");
    }

    // POST: api/auth/register/client
    [HttpPost("register/client")]
    public IActionResult RegisterClient([FromBody] ClientModel clientModel)
    {
        try
        {
            AuthenticationManager.Instance.CreateClientAccount(_context, clientModel.Email, clientModel.Password, clientModel.CPF, clientModel.FirstName, clientModel.LastName);
            return Ok("Client registration successful");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // POST: api/auth/register/provider
    [HttpPost("register/provider")]
    public IActionResult RegisterProvider([FromBody] ProviderModel providerModel)
    {
        try
        {
            AuthenticationManager.Instance.CreateProviderAccount(_context, providerModel.Email, providerModel.Password, providerModel.Name, providerModel.CNPJ);
            return Ok("Provider registration successful");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
