using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SteelHorseTrucks.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SteelHorseTrucks.Controllers
{
    [Authorize]
    public class MFAController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly EmailSender _emailSender;

        public MFAController(UserManager<IdentityUser> userManager, EmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> Verify()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            if (TempData["MFACodeSent"] == null)
            {
                var code = new System.Random().Next(100000, 999999).ToString();
                await _emailSender.SendEmailAsync(user.Email, "Your MFA Authentication Code", $"Your code is: {code}");
                HttpContext.Session.SetString("MfaCode", code);
                TempData["MFACode"] = code;
                TempData["MFACodeSent"] = true;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Verify(string inputCode)
        {
            var storedCode = HttpContext.Session.GetString("MfaCode");

            if (storedCode == inputCode)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                TempData.Remove("MFACode");
                TempData.Remove("MFACodeSent");
                HttpContext.Session.Remove("MfaCode");

                var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

                if (isAdmin)
                {
                    return Redirect("/Admin");
                }
                else
                {
                    return Redirect("/Trucks");
                }
            }

            ViewBag.Error = "Invalid MFA code. Please try again.";
            return View();
        }

        [HttpGet]
        public IActionResult MFACode()
        {
            ViewBag.Code = TempData["MFACode"];
            return View();
        }
    }
}
