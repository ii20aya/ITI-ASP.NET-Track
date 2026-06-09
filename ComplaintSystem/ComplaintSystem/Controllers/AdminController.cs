using ComplaintSystem.Models.Enum;
using ComplaintSystem.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintSystem.Controllers
{
    /// <summary>
    /// Admin controller — thin orchestrator.
    /// All business logic lives in IAdminService.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _svc;

        public AdminController(IAdminService svc) => _svc = svc;

        // ── GET /Admin/Dashboard ──────────────────────────────────────────
        public async Task<IActionResult> Dashboard()
        {
            var (complaints, stats) = await _svc.GetDashboardDataAsync();

            ViewBag.TotalComplaints = stats.Total;
            ViewBag.Pending         = stats.Pending;
            ViewBag.InProgress      = stats.InProgress;
            ViewBag.Resolved        = stats.Resolved;
            ViewBag.Rejected        = stats.Rejected;

            return View(complaints);
        }

        // ── POST /Admin/UpdateStatus ──────────────────────────────────────
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, ComplaintStatus status)
        {
            var (ok, error) = await _svc.UpdateStatusAsync(id, status);
            TempData[ok ? "Success" : "Error"] = ok ? $"✅ Status updated to {status}." : error;
            return RedirectToAction(nameof(Dashboard));
        }

        // ── POST /Admin/AddReply ──────────────────────────────────────────
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReply(int complaintId, string content)
        {
            var (ok, error) = await _svc.AddReplyAsync(complaintId, content);
            TempData[ok ? "Success" : "Error"] = ok ? "💬 Reply posted." : error;
            return RedirectToAction(nameof(Dashboard));
        }

        // ── POST /Admin/DeleteReply ───────────────────────────────────────
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReply(int replyId, int complaintId)
        {
            var (ok, error) = await _svc.DeleteReplyAsync(replyId);
            TempData[ok ? "Success" : "Error"] = ok ? "🗑️ Reply deleted." : error;
            return RedirectToAction(nameof(Dashboard));
        }
    }
}
