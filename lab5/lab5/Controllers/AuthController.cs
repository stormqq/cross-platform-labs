using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Auth0.AspNetCore.Authentication;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab5.Models;
using Microsoft.AspNetCore.Authorization;

namespace lab5.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }
    
    public async Task Login()
    {
        var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri(Url.Action("Labs", "Labs"))
            .Build();

        await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    }
    
    [Authorize]
    public async Task Logout()
    {
        var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
            .WithRedirectUri(Url.Action("Index", "Home"))
            .Build();

        await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    [Authorize]
    public IActionResult Profile()
    {
        return View(new UserModel()
        {
            Email = User.Identity.Name,
            Login = User.Claims.FirstOrDefault(c => c.Type == "username")?.Value,
            Phone = User.Claims.FirstOrDefault(c => c.Type == "phone")?.Value,
            FullName = User.Claims.FirstOrDefault(c => c.Type == "full_name")?.Value,
            Image = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}