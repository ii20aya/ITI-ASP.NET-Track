// ── IAdminService.cs ──────────────────────────────────────────────────────────
// Place in: Service/Interface/IAdminService.cs

using ComplaintSystem.Models.Enum;
using ComplaintSystem.ViewModels;

namespace ComplaintSystem.Service.Interface
{
    /// <summary>
    /// Admin-specific operations (status updates, reply management).
    /// Re-uses IComplaintService for shared logic.
    /// </summary>
    public interface IAdminService
    {
        Task<(List<ComplaintSystem.Models.Complaint> complaints, DashboardStatsVM stats)>
            GetDashboardDataAsync();

        Task<(bool ok, string? error)> UpdateStatusAsync(int id, ComplaintStatus status);
        Task<(bool ok, string? error)> AddReplyAsync(int complaintId, string content);
        Task<(bool ok, string? error)> DeleteReplyAsync(int replyId);
    }
}


