using ComplaintSystem.Models.Enum;
using ComplaintSystem.Service.Interface;
using ComplaintSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ComplaintSystem.Controllers
{
    /// <summary>
    /// Complaint controller — thin orchestrator.
    /// Every action is ≤ 15 lines: call service → set TempData → return View/Redirect.
    /// Zero EF, zero raw SQL, zero business logic here.
    /// </summary>
    [Authorize]
    public class ComplaintController : Controller
    {
        private readonly IComplaintService _svc;

        public ComplaintController(IComplaintService svc) => _svc = svc;

        // ── GET /Complaint/Index ───────────────────────────────────────────
        public async Task<IActionResult> Index()
        {
            var list = await _svc.GetAllComplaintsAsync();

            // Cookie-persisted filter (unchanged behaviour)
            ViewBag.LastFilter = Request.Cookies["LastStatusFilter"] ?? "All";

            // Session visit counter (unchanged behaviour)
            var views = HttpContext.Session.GetInt32("ComplaintViews") ?? 0;
            HttpContext.Session.SetInt32("ComplaintViews", ++views);
            ViewBag.SessionViews = views;

            return View(list);
        }

        // ── GET /Complaint/Details/5 ──────────────────────────────────────
        public async Task<IActionResult> Details(int id)
        {
            var vm = await _svc.GetComplaintDetailsAsync(id);
            if (vm is null)
            {
                TempData["Error"] = $"Complaint #{id} was not found.";
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // ── GET /Complaint/Chat/5 ─────────────────────────────────────────
        public async Task<IActionResult> Chat(int id)
        {
            var vm = await _svc.GetChatVMAsync(id);
            if (vm is null)
            {
                TempData["Error"] = "Complaint not found.";
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // ── GET /Complaint/Create ─────────────────────────────────────────
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new ComplaintCreateVM
            {
                Categories = await _svc.GetCategorySelectListAsync()
            };
            return View(vm);
        }

        // ── POST /Complaint/Create ────────────────────────────────────────
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ComplaintCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = await _svc.GetCategorySelectListAsync();
                return View(vm);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var (ok, error) = await _svc.CreateComplaintAsync(vm, userId);

            if (!ok)
            {
                ModelState.AddModelError(nameof(vm.Title), error!);
                vm.Categories = await _svc.GetCategorySelectListAsync();
                return View(vm);
            }

            TempData["Success"] = "✅ Complaint submitted successfully!";
            return RedirectToAction(nameof(Index));
        }

        // ── GET /Complaint/Edit/5 ─────────────────────────────────────────
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _svc.GetComplaintForEditAsync(id);
            if (vm is null)
            {
                TempData["Error"] = "Complaint not found.";
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // ── POST /Complaint/Edit/5 ────────────────────────────────────────
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ComplaintEditVM vm)
        {
            if (id != vm.Id) return BadRequest();

            if (!ModelState.IsValid)
            {
                vm.Categories = await _svc.GetCategorySelectListAsync();
                vm.Statuses   = _svc.GetStatusSelectList();
                return View(vm);
            }

            var (ok, error) = await _svc.UpdateComplaintAsync(vm);

            if (!ok)
            {
                ModelState.AddModelError(nameof(vm.Title), error!);
                vm.Categories = await _svc.GetCategorySelectListAsync();
                vm.Statuses   = _svc.GetStatusSelectList();
                return View(vm);
            }

            TempData["Success"] = "✅ Complaint updated.";
            return RedirectToAction(nameof(Details), new { id });
        }

        // ── GET /Complaint/Delete/5 ───────────────────────────────────────
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var vm = await _svc.GetComplaintDetailsAsync(id);
            if (vm is null)
            {
                TempData["Error"] = "Complaint not found.";
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // ── POST /Complaint/Delete/5 ──────────────────────────────────────
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var (ok, error) = await _svc.DeleteComplaintAsync(id);
            TempData[ok ? "Success" : "Error"] = ok ? "🗑️ Complaint deleted." : error;
            return RedirectToAction(nameof(Index));
        }

        // ── POST /Complaint/AddReply ──────────────────────────────────────
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReply(
            [Bind(Prefix = "NewReply")] AddReplyVM vm)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Reply content is required (2–1000 characters).";
                return RedirectToAction(nameof(Details), new { id = vm.ComplaintId });
            }

            var (ok, error) = await _svc.AddReplyAsync(vm.ComplaintId, vm.Content);
            TempData[ok ? "Success" : "Error"] = ok ? "💬 Reply posted!" : error;
            return RedirectToAction(nameof(Details), new { id = vm.ComplaintId });
        }

        // ── AJAX Remote Validation ────────────────────────────────────────
        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> IsTitleUnique(string title, int? id)
        {
            bool unique = await _svc.IsTitleUniqueAsync(title, id);
            return unique
                ? Json(true)
                : Json($"A complaint titled '{title}' already exists.");
        }

        // ── POST /Complaint/SetFilter ─────────────────────────────────────
        [HttpPost]
        public IActionResult SetFilter(string status)
        {
            Response.Cookies.Append("LastStatusFilter", status,
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            return RedirectToAction(nameof(Index));
        }
    }
}
