using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace OkaDemo.Controllers;
public class LoginController : Controller
{
    [HttpGet("login")]
    public IActionResult Login([FromQuery]string returnUrl)
    {
        var redirectUri = returnUrl is null ? Url.Content("~/") : $"/{returnUrl}";

        if (User.Identity.IsAuthenticated)
            return LocalRedirect(redirectUri);

        return Challenge();
    }

    [HttpGet("logout")]
    public async Task<ActionResult> Logout([FromQuery] string returnUrl)
    {
        var redirectUri = returnUrl is null ? Url.Content("~/") : $"/{returnUrl}";

        if (!User.Identity.IsAuthenticated)
            return LocalRedirect(redirectUri);

        await  HttpContext.SignOutAsync();

        return LocalRedirect(redirectUri);
    }
}
