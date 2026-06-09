using ComplaintSystem.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComplaintSystem.Service.Interface
{
    /// <summary>
    /// Business logic layer for complaints.
    /// Returns ViewModels (not entities) — the controller just passes them to the View.
    /// Never touches HttpContext, TempData, or IActionResult.
    /// </summary>
    public interface IComplaintService
    {
        // ── List / Read ───────────────────────────────────────────────────
        Task<List<ComplaintListItemVM>> GetAllComplaintsAsync();
        Task<List<ComplaintListItemVM>> GetUserComplaintsAsync(string userId);
        Task<ComplaintDetailsVM?>       GetComplaintDetailsAsync(int id);
        Task<ComplaintEditVM?>          GetComplaintForEditAsync(int id);
        Task<ChatVM?>                   GetChatVMAsync(int id);

        // ── Validation ────────────────────────────────────────────────────
        Task<bool> IsTitleUniqueAsync(string title, int? excludeId = null);

        // ── Write — returns (success, errorMessage) ───────────────────────
        Task<(bool ok, string? error)> CreateComplaintAsync(
            ComplaintCreateVM vm, string userId);

        Task<(bool ok, string? error)> UpdateComplaintAsync(
            ComplaintEditVM vm);

        Task<(bool ok, string? error)> DeleteComplaintAsync(int id);

        Task<(bool ok, string? error)> AddReplyAsync(
            int complaintId, string content);

        Task<(bool ok, string? error)> DeleteReplyAsync(int replyId);

        Task<(bool ok, string? error)> UpdateStatusAsync(
            int complaintId, ComplaintSystem.Models.Enum.ComplaintStatus status);

        // ── Dropdown helpers ──────────────────────────────────────────────
        Task<IEnumerable<SelectListItem>> GetCategorySelectListAsync();
        IEnumerable<SelectListItem>       GetStatusSelectList();

        // ── Stats (for dashboards) ────────────────────────────────────────
        Task<DashboardStatsVM> GetAdminStatsAsync();
        Task<UserDashboardStatsVM> GetUserStatsAsync(string userId);
    }
}
