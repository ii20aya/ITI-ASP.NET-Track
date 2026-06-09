// ════════════════════════════════════════════════════════════════════════════
// AdminService.cs
// Place in: Service/Implementation/AdminService.cs
// ════════════════════════════════════════════════════════════════════════════
using ComplaintSystem.Models;
using ComplaintSystem.Models.Enum;
using ComplaintSystem.Reposatory.Interface;
using ComplaintSystem.Service.Interface;
using ComplaintSystem.ViewModels;

namespace ComplaintSystem.Service.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IRepository _repo;
        private readonly ILogger<AdminService> _logger;

        public AdminService(IRepository repo, ILogger<AdminService> logger)
        {
            _repo   = repo;
            _logger = logger;
        }

        public async Task<(List<Complaint> complaints, DashboardStatsVM stats)>
            GetDashboardDataAsync()
        {
            var all = (await _repo.GetAllAsync<Complaint>(
                c => c.Category!,
                c => c.Replies))
                .OrderByDescending(c => c.CreatedAt)
                .ToList();

            var stats = new DashboardStatsVM
            {
                Total      = all.Count,
                Pending    = all.Count(c => c.Status == ComplaintStatus.Pending),
                InProgress = all.Count(c => c.Status == ComplaintStatus.InProgress),
                Resolved   = all.Count(c => c.Status == ComplaintStatus.Resolved),
                Rejected   = all.Count(c => c.Status == ComplaintStatus.Rejected)
            };

            return (all, stats);
        }

        public async Task<(bool ok, string? error)> UpdateStatusAsync(
            int id, ComplaintStatus status)
        {
            try
            {
                var entity = await _repo.GetByIdAsync<Complaint>(id);
                if (entity is null)
                    return (false, $"Complaint #{id} not found.");

                entity.Status    = status;
                entity.UpdatedAt = DateTime.UtcNow;
                await _repo.UpdateAsync(entity);
                return (true, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AdminService.UpdateStatusAsync id={Id}", id);
                return (false, "Unexpected error updating status.");
            }
        }

        public async Task<(bool ok, string? error)> AddReplyAsync(
            int complaintId, string content)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(content))
                    return (false, "Reply content cannot be empty.");

                var complaint = await _repo.GetByIdAsync<Complaint>(complaintId);
                if (complaint is null)
                    return (false, $"Complaint #{complaintId} not found.");

                var reply = new Reply
                {
                    ComplaintId = complaintId,
                    Content     = content.Trim(),
                    CreatedAt   = DateTime.UtcNow
                };

                await _repo.CreateAsync(reply);
                return (true, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AdminService.AddReplyAsync complaintId={Id}", complaintId);
                return (false, "Unexpected error adding reply.");
            }
        }

        public async Task<(bool ok, string? error)> DeleteReplyAsync(int replyId)
        {
            try
            {
                var reply = await _repo.GetByIdAsync<Reply>(replyId);
                if (reply is null)
                    return (false, $"Reply #{replyId} not found.");

                await _repo.DeleteAsync(reply);
                return (true, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AdminService.DeleteReplyAsync id={Id}", replyId);
                return (false, "Unexpected error deleting reply.");
            }
        }
    }
}


