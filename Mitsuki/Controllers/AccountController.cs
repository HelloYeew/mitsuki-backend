using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mitsuki.Models;

namespace Mitsuki.Controllers;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly UserManager<User> _userManager;  
    private readonly SignInManager<User> _signInManager;  

    public AccountController(ILogger<AccountController> logger, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    [HttpGet(Name = "Get current user")]
    [Authorize]
    public async Task<User> GetCurrentUser()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null)
        {
            throw new UnauthorizedAccessException();
        }
        return new User
        {
            Id = user.Id,
            UserName = user.UserName,
        };
    }
}