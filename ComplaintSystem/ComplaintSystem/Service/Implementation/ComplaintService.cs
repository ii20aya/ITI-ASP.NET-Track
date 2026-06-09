using ComplaintSystem.Models;
using ComplaintSystem.Models.Enum;
using ComplaintSystem.Reposatory.Interface;
using ComplaintSystem.Service.Interface;
using ComplaintSystem.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComplaintSystem.Service.Implementation
{
    /// <summary>
    /// Complaint business logic.
    ///   • Reads entities via IRepository
    ///   • Maps to/from ViewModels
    ///   • Returns plain results — NO HttpContext, NO TempData, NO IActionResult
    /// </summary>
    public class ComplaintService : IComplaintService
    {
        private readonly IRepository _repo;
        private readonly ILogger<ComplaintService> _logger;

        public ComplaintService(IRepository repo, ILogger<ComplaintService> logger)
        {
            _repo   = repo;
            _logger = logger;
        }

        // ════════════════════════════════════════════════════════════════
        // READ
        // ════════════════════════════════════════════════════════════════

        public async Task<List<ComplaintListItemVM>> GetAllComplaintsAsync()
        {
            var complaints = await _repo.GetAllAsync<Complaint>(
                c => c.Category!,
                c => c.Replies);

            return complaints
                .OrderByDescending(c => c.CreatedAt)
                .Select(MapToListItem)
                .ToList();
        }

        public async Task<List<ComplaintListItemVM>> GetUserComplaintsAsync(string userId)
        {
            var complaints = await _repo.FindAsync<Complaint>(
                c => c.UserId == userId,
                c => c.Category!,
                c => c.Replies);

            return complaints
                .OrderByDescending(c => c.CreatedAt)
                .Select(MapToListItem)
                .ToList();
        }

        public async Task<ComplaintDetailsVM?> GetComplaintDetailsAsync(int id)
        {
            var c = await _repo.GetByIdAsync<Complaint>(id,
                x => x.Category!,
                x => x.Replies);

            if (c is null) return null;

            return new ComplaintDetailsVM
            {
                Id               = c.Id,
                Title            = c.Title,
                Description      = c.Description,
                Status           = c.Status,
                CreatedAt        = c.CreatedAt,
                UpdatedAt        = c.UpdatedAt,
                CategoryName     = c.Category?.Name     ?? string.Empty,
                CategoryImageUrl = c.Category?.ImageUrl ?? string.Empty,
                Replies = c.Replies
                    .OrderBy(r => r.CreatedAt)
                    .Select(r => new ReplyVM
                    {
                        Id        = r.Id,
                        Content   = r.Content,
                        CreatedAt = r.CreatedAt
                    })
                    .ToList(),
                NewReply = new AddReplyVM { ComplaintId = id }
            };
        }

        public async Task<ComplaintEditVM?> GetComplaintForEditAsync(int id)
        {
            var c = await _repo.GetByIdAsync<Complaint>(id);
            if (c is null) return null;

            return new ComplaintEditVM
            {
                Id          = c.Id,
                Title       = c.Title,
                Description = c.Description,
                CategoryId  = c.CategoryId,
                Status      = c.Status,
                Categories  = await GetCategorySelectListAsync(),
                Statuses    = GetStatusSelectList()
            };
        }

        public async Task<ChatVM?> GetChatVMAsync(int id)
        {
            var c = await _repo.GetByIdAsync<Complaint>(id);
            if (c is null) return null;

            return new ChatVM
            {
                ComplaintId    = id,
                ComplaintTitle = c.Title,
                History        = await _repo.GetChatHistoryAsync(id)
            };
        }

        // ════════════════════════════════════════════════════════════════
        // VALIDATION
        // ════════════════════════════════════════════════════════════════

        public async Task<bool> IsTitleUniqueAsync(string title, int? excludeId = null)
        {
            var normalised = title.Trim().ToLowerInvariant();

            bool exists = excludeId.HasValue
                ? await _repo.ExistsAsync<Complaint>(
                      c => c.Title.ToLower() == normalised && c.Id != excludeId.Value)
                : await _repo.ExistsAsync<Complaint>(
                      c => c.Title.ToLower() == normalised);

            return !exists;   // true = unique (valid)
        }

        // ════════════════════════════════════════════════════════════════
        // WRITE
        // ════════════════════════════════════════════════════════════════

        public async Task<(bool ok, string? error)> CreateComplaintAsync(
            ComplaintCreateVM vm, string userId)
        {
            try
            {
                if (!await IsTitleUniqueAsync(vm.Title))
                    return (false, $"A complaint with the title '{vm.Title}' already exists.");

                var entity = new Complaint
                {
                    Title       = vm.Title.Trim(),
                    Description = vm.Description.Trim(),
                    CategoryId  = vm.CategoryId,
                    UserId      = userId,
                    Status      = ComplaintStatus.Pending,
                    CreatedAt   = DateTime.UtcNow
                };

                await _repo.CreateAsync(entity);
                return (true, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateComplaintAsync failed");
                return (false, "An unexpected error occurred. Please try again.");
            }
        }

        public async Task<(bool ok, string? error)> UpdateComplaintAsync(ComplaintEditVM vm)
        {
            try
            {
                var entity = await _repo.GetByIdAsync<Complaint>(vm.Id);
                if (entity is null)
                    return (false, $"Complaint #{vm.Id} not found.");

                if (!await IsTitleUniqueAsync(vm.Title, vm.Id))
                    return (false, $"Another complaint with the title '{vm.Title}' already exists.");

                entity.Title       = vm.Title.Trim();
                entity.Description = vm.Description.Trim();
                entity.CategoryId  = vm.CategoryId;
                entity.Status      = vm.Status;
                entity.UpdatedAt   = DateTime.UtcNow;

                await _repo.UpdateAsync(entity);
                return (true, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateComplaintAsync id={Id} failed", vm.Id);
                return (false, "An unexpected error occurred. Please try again.");
            }
        }

        public async Task<(bool ok, string? error)> DeleteComplaintAsync(int id)
        {
            try
            {
                var entity = await _repo.GetByIdAsync<Complaint>(id);
                if (entity is null)
                    return (false, $"Complaint #{id} not found.");

                await _repo.DeleteAsync(entity);
                return (true, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeleteComplaintAsync id={Id} failed", id);
                return (false, "An unexpected error occurred. Please try again.");
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
                _logger.LogError(ex, "AddReplyAsync complaintId={Id} failed", complaintId);
                return (false, "An unexpected error occurred. Please try again.");
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
                _logger.LogError(ex, "DeleteReplyAsync id={Id} failed", replyId);
                return (false, "An unexpected error occurred. Please try again.");
            }
        }

        public async Task<(bool ok, string? error)> UpdateStatusAsync(
            int complaintId, ComplaintStatus status)
        {
            try
            {
                var entity = await _repo.GetByIdAsync<Complaint>(complaintId);
                if (entity is null)
                    return (false, $"Complaint #{complaintId} not found.");

                entity.Status    = status;
                entity.UpdatedAt = DateTime.UtcNow;

                await _repo.UpdateAsync(entity);
                return (true, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateStatusAsync id={Id} failed", complaintId);
                return (false, "An unexpected error occurred. Please try again.");
            }
        }

        // ════════════════════════════════════════════════════════════════
        // DROPDOWN HELPERS
        // ════════════════════════════════════════════════════════════════

        public async Task<IEnumerable<SelectListItem>> GetCategorySelectListAsync()
        {
            var categories = await _repo.GetAllAsync<Category>();
            return categories
                .OrderBy(c => c.Name)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text  = c.Name
                });
        }

        public IEnumerable<SelectListItem> GetStatusSelectList()
            => Enum.GetValues<ComplaintStatus>()
                .Select(s => new SelectListItem
                {
                    Value = ((int)s).ToString(),
                    Text  = s.ToString()
                });

        // ════════════════════════════════════════════════════════════════
        // STATS
        // ════════════════════════════════════════════════════════════════

        public async Task<DashboardStatsVM> GetAdminStatsAsync()
        {
            var all = await _repo.GetAllAsync<Complaint>();
            var list = all.ToList();

            return new DashboardStatsVM
            {
                Total      = list.Count,
                Pending    = list.Count(c => c.Status == ComplaintStatus.Pending),
                InProgress = list.Count(c => c.Status == ComplaintStatus.InProgress),
                Resolved   = list.Count(c => c.Status == ComplaintStatus.Resolved),
                Rejected   = list.Count(c => c.Status == ComplaintStatus.Rejected)
            };
        }

        public async Task<UserDashboardStatsVM> GetUserStatsAsync(string userId)
        {
            var all = await _repo.FindAsync<Complaint>(c => c.UserId == userId);
            var list = all.ToList();

            return new UserDashboardStatsVM
            {
                Total      = list.Count,
                Pending    = list.Count(c => c.Status == ComplaintStatus.Pending),
                InProgress = list.Count(c => c.Status == ComplaintStatus.InProgress),
                Resolved   = list.Count(c => c.Status == ComplaintStatus.Resolved),
                Rejected   = list.Count(c => c.Status == ComplaintStatus.Rejected)
            };
        }

        // ════════════════════════════════════════════════════════════════
        // PRIVATE MAPPING
        // ════════════════════════════════════════════════════════════════

        private static ComplaintListItemVM MapToListItem(Complaint c) =>
            new()
            {
                Id               = c.Id,
                Title            = c.Title,
                Status           = c.Status,
                CreatedAt        = c.CreatedAt,
                CategoryName     = c.Category?.Name     ?? string.Empty,
                CategoryImageUrl = c.Category?.ImageUrl ?? string.Empty,
                RepliesCount     = c.Replies.Count
            };
    }
}
