using ComplaintSystem.Models;
using ComplaintSystem.ViewModels;
using global::ComplaintSystem.Models;
namespace ComplaintSystem.Service.Interface
{
    // ── IUserService.cs ───────────────────────────────────────────────────────────
    // Place in: Service/Interface/IUserService.cs


        /// <summary>
        /// User dashboard — fetches only the current user's data.
        /// </summary>
        public interface IUserService
        {
            Task<(List<Complaint> complaints, UserDashboardStatsVM stats)>
                GetDashboardDataAsync(string userId);
        }
    }


