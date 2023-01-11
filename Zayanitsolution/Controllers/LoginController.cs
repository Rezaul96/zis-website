using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using Scorerecord.DTOS;
using System.Security.Claims;
using Scorerecord.Services;
using Infrastructure.Shared.Services;
using MimeKit;
using Infrastructure.Shared.DTO;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Scorerecord.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMemberService _userService;
        private readonly IEmailService _emailService;
        IWebHostEnvironment _env;
        public LoginController(IMemberService userService, IWebHostEnvironment env, IEmailService emailService)
        {
            _userService = userService;
            _env = env;
            _emailService = emailService;
        }
        public IActionResult Login(string returnUrl = "/")
        {
            AuthenticationRequest authenticationRequest = new AuthenticationRequest();
            authenticationRequest.ReturnUrl = returnUrl;
            return View(authenticationRequest);
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        public async Task<IActionResult> ResetPassword(string id)
        {
            ResetPasswordRequest reset = new ResetPasswordRequest();
            var member = await _userService.GetAsync(Guid.Parse(id));
            if(member == null)
                return RedirectToAction("ForgetPassword");
            reset.Token = member.OTP;
            reset.Email = member.Email;
            reset.Id = member.Id.ToString();
            return View(reset);
        }
        public IActionResult Verify(string id)
        {
            VerifyRequest verifyRequest = new VerifyRequest();
            verifyRequest.Id = id;
            return View(verifyRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationRequest authentication)
        {
            if (ModelState.IsValid)
            {
                if (_userService.IsExistUserName(authentication.Email))
                {
                    var user = _userService.Login(authentication.Email, authentication.Password);
                    if (user != null)
                    {
                        var claims = new List<Claim>() {
                             new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                             new Claim(ClaimTypes.Email, user.Email),
                             new Claim(ClaimTypes.Name, user.Name),
                             new Claim(ClaimTypes.Dns, user.Image==null?"":user.Image),
                             new Claim(ClaimTypes.Sid, user.Mobile.ToString()),
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                        {
                            IsPersistent = authentication.RememberMe
                        });
                        if (authentication.ReturnUrl == null)
                        {
                            return RedirectToAction(nameof(Index), "FacilitatorDashboard", new { Area = "Facilitator" });
                        }
                        else
                        {
                            //return LocalRedirect(authentication.ReturnUrl);
                            return RedirectToAction(nameof(Index), "Event", new { Area = "Facilitator" });

                        }
                    }

                    return View(authentication);
                }
                ViewBag.Email = "Your email is not valid";
                return View(authentication);
            }
            return View(authentication);
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgotPasswordRequest request)
        {
            var model = _userService.GetByEmail(request.Email);
            if (model != null)
            {
                var pathToFile = _env.WebRootPath
                + Path.DirectorySeparatorChar.ToString()
                + "Templates"
                + Path.DirectorySeparatorChar.ToString()
                + "EmailTemplate"
                + Path.DirectorySeparatorChar.ToString()
                + "RoyexDigitalContactUs.html";

                var subject = "Scorerecord OTP";

                var builder = new BodyBuilder();
                using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }
                model.OTP = RandomNumber.GenerateRandomNo();
                string messageBody = string.Format(builder.HtmlBody,
                    model.FirstName + " " + model.LastName,
                    model.Email,
                    model.Mobile, model.OTP
                    );
                await _userService.UpdateMember(model.Id, model);
                var emailRequest = new EmailRequest
                {
                    Body = messageBody,
                    Subject = subject,
                    From = "info@royex.net",
                    To = model.Email
                };
                await _emailService.SendAsync(emailRequest);
            }
            return RedirectToAction("Verify", new { id=model.Id});
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            if(ModelState.IsValid && request.Password==request.ConfirmPassword)
            {
                if (await _userService.PasswordReset(Guid.Parse(request.Id), request.Password))
                    return RedirectToAction("Login");
            }
            return RedirectToAction("ForgetPassword");
        }
        [HttpPost]
        public async Task<IActionResult> Verify(VerifyRequest request)
        {
            var member = await _userService.GetAsync(Guid.Parse(request.Id));
            if(member != null)
            {
                string otp=request.One.ToString()+request.Two.ToString()+request.Three.ToString()+request.Four.ToString();
                if (otp == member.OTP)
                {
                    return RedirectToAction("ResetPassword",new {id=member.Id});

                }
            }
            return RedirectToAction("ForgetPassword");
        }
    }
}
