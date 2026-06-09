    using ComplaintSystem.Models;
    using ComplaintSystem.Models.Enum;
    using ComplaintSystem.Reposatory.Interface;
    using ComplaintSystem.Service.Interface;
using ComplaintSystem.ViewModels;


namespace ComplaintSystem.Service.Implementation
    {
        public class UserService : IUserService
        {
            private readonly IRepository _repo;
            private readonly ILogger<UserService> _logger;

            public UserService(IRepository repo, ILogger<UserService> logger)
            {
                _repo = repo;
                _logger = logger;
            }

            public async Task<(List<Complaint> complaints, UserDashboardStatsVM stats)>
                GetDashboardDataAsync(string userId)
            {
                var all = (await _repo.FindAsync<Complaint>(
                    c => c.UserId == userId,
                    c => c.Category!,
                    c => c.Replies))
                    .OrderByDescending(c => c.CreatedAt)
                    .ToList();

                var stats = new UserDashboardStatsVM
                {
                    Total = all.Count,
                    Pending = all.Count(c => c.Status == ComplaintStatus.Pending),
                    InProgress = all.Count(c => c.Status == ComplaintStatus.InProgress),
                    Resolved = all.Count(c => c.Status == ComplaintStatus.Resolved),
                    Rejected = all.Count(c => c.Status == ComplaintStatus.Rejected)
                };

                return (all, stats);
            }
        }
    }


