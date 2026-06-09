using ComplaintSystem.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ComplaintSystem.Controllers
{
    /// <summary>
    /// User dashboard controller — thin orchestrator.
    /// All data fetching lives in IUserService.
    /// </summary>
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly IUserService _svc;

        public UserController(IUserService svc) => _svc = svc;

        // ── GET /User/Dashboard ───────────────────────────────────────────
        public async Task<IActionResult> Dashboard()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var (complaints, stats) = await _svc.GetDashboardDataAsync(userId);

            ViewBag.TotalCount    = stats.Total;
            ViewBag.PendingCount  = stats.Pending;
            ViewBag.DoneCount     = stats.Resolved;
            ViewBag.RejectedCount = stats.Rejected;
            ViewBag.UserName      = User.Identity?.Name?.Split('@')[0] ?? "User";
            ViewBag.UserEmail     = User.Identity?.Name ?? string.Empty;

            return View(complaints);
        }
    }
}
