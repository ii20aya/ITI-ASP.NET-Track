using ComplaintSystem.Models;
using ComplaintSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintSystem.Controllers
{
    /// <summary>
    /// Account controller — handles Register / Login / Logout.
    /// No service layer needed here: ASP.NET Identity IS the service.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser>   _um;
        private readonly SignInManager<ApplicationUser> _sm;

        public AccountController(
            UserManager<ApplicationUser>   um,
            SignInManager<ApplicationUser> sm)
        {
            _um = um;
            _sm = sm;
        }

        // ── GET /Account/Register ─────────────────────────────────────────
        public IActionResult Register() => View();

        // ── POST /Account/Register ────────────────────────────────────────
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email    = model.Email,
                FullName = model.FullName
            };

            var result = await _um.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _um.AddToRoleAsync(user, "User");
                await _sm.SignInAsync(user, isPersistent: false);
                TempData["Success"] = "Welcome! Your account has been created.";
                return RedirectToAction("Index", "Home");
            }

            foreach (var e in result.Errors)
                ModelState.AddModelError(string.Empty, e.Description);

            return View(model);
        }

        // ── GET /Account/Login ────────────────────────────────────────────
        public IActionResult Login(string? returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // ── POST /Account/Login ───────────────────────────────────────────
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _sm.PasswordSignInAsync(
                model.Email, model.Password,
                model.RememberMe,
                lockoutOnFailure: true);

            if (result.Succeeded)
            {
                TempData["Success"] = "Logged in successfully!";
                return LocalRedirect(returnUrl ?? "/");
            }

            if (result.IsLockedOut)
                ModelState.AddModelError(string.Empty, "Account locked. Try again later.");
            else
                ModelState.AddModelError(string.Empty, "Invalid email or password.");

            return View(model);
        }

        // ── POST /Account/Logout ──────────────────────────────────────────
        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _sm.SignOutAsync();
            HttpContext.Session.Clear();
            TempData["Success"] = "You have been logged out.";
            return RedirectToAction("Index", "Home");
        }
    }
}
