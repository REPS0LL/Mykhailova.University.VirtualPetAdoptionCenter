using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VirtualPetAdoptionCenter.Core;
using VirtualPetAdoptionCenter.Core.Services;
using VirtualPetAdoptionCenter.Models.NewFolder1;
using VirtualPetAdoptionCenter.Models.RequestModels;



namespace VirtualPetAdoptionCenter.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accService)
    {
        _accountService = accService;
    }


    [HttpPost]
    [Route(nameof(SignInGoogle))]
    public IActionResult SignInGoogle()
    {
        var authenticationProperties = new AuthenticationProperties
        {
            RedirectUri = Url.Action(nameof(GoogleLoginCallback)),
            Items = { { "scheme", "Google" } }
        };

        return Challenge(authenticationProperties, "Google");
    }

    [HttpGet(Name = "GoogleLoginCallback")]
    public async Task<IActionResult> GoogleLoginCallback()
    {
        var authenticateResult = await HttpContext.AuthenticateAsync("Google");

        if (!authenticateResult.Succeeded)
        {
            return BadRequest("Failed to authenticate with Google");
        }

        var emailClaim = authenticateResult.Principal.FindFirst(ClaimTypes.Email);
        var email = emailClaim?.Value;

        if (string.IsNullOrEmpty(email))
        {
            return BadRequest("Invalid user claim");
        }

        var user = await _accountService.CheckUserExistsAsync(email, "", AuthType.Google);

        if (user != null)
        {
            HttpContext.Session.SetInt32(Constants.UserCookieKey, user.Id);

            return RedirectToPage("/AllPets");
        }
        else
        {
            user = await _accountService.RegisterUserAsync(email, "", AuthType.Google);

            if (user != null)
            {
                HttpContext.Session.SetInt32(Constants.UserCookieKey, user.Id);

                return RedirectToPage("/AllPets"); 
            }
            else
            {
                return BadRequest("Failed to create account");
            }
        }
    }


    [HttpPost]
    [Route(nameof(SignIn))]
    public async Task<IActionResult> SignIn([FromForm] LoginRequest request)
    {
        var user = await _accountService.CheckUserExistsAsync(request.Login, request.Password, AuthType.Default);

        if (user != null)
        {
            HttpContext.Session.SetInt32(Constants.UserCookieKey, user.Id);
            return RedirectToPage("/AllPets"); // Redirect to AllPets action
        }
        else
        {
            return BadRequest("Invalid login or password");
        }
    }

    [HttpPost]
    [Route(nameof(SignUp))]
    public async Task<IActionResult> SignUp([FromForm] LoginRequest request)
    {
        var user = await _accountService.RegisterUserAsync(request.Login, request.Password, AuthType.Default);

        if (user != null)
        {
            HttpContext.Session.SetInt32(Constants.UserCookieKey, user.Id);
            return RedirectToPage("/AllPets");
        }
        else
        {
            return BadRequest("Account already exists");
        }

    }

    [HttpPost]
    [Route(nameof(SignInMicrosoft))]
    [Authorize]
    public async Task<IActionResult> SignInMicrosoft()
    {
        if (User.Identity?.IsAuthenticated != null)
        {
            var preferredUsernameClaim = User.Claims.FirstOrDefault(c => c.Type.Equals("preferred_username"));
            var name = User.Claims.FirstOrDefault(c => c.Type.Equals("name"));
            var email = User.Claims.FirstOrDefault(c => c.Type.Equals("preferred_username")).Value;

            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Invalid user claim");
            }
            
            var user = await _accountService.CheckUserExistsAsync(email, "", AuthType.Microsoft);

            if (user != null)
            {
                HttpContext.Session.SetInt32(Constants.UserCookieKey, user.Id);
                return RedirectToPage("/AllPets");
            }
            else
            {
                var registeredUser = await _accountService.RegisterUserAsync(email, "", AuthType.Microsoft);

                if (registeredUser != null)
                {
                    HttpContext.Session.SetInt32(Constants.UserCookieKey, user.Id);
                    return RedirectToPage("/AllPets");
                }
                else
                {
                    return BadRequest("Failed to create account");
                }
            }
        }
        return BadRequest("Failed to process request");
    }
}

        