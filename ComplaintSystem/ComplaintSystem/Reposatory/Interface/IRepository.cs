using ComplaintSystem.Models;
using System.Linq.Expressions;

namespace ComplaintSystem.Reposatory.Interface
{
    public interface IRepository 

    {
        //crud on database

        Task<IEnumerable<T>> GetAllAsync<T>(
            params Expression<Func<T, object>>[] includes)
            where T : class;
    
            Task<T?> GetByIdAsync<T>(
                int id,
                params Expression<Func<T, object>>[] includes)
                where T : class;

            Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> predicate)
                where T : class;

            Task<IEnumerable<T>> FindAsync<T>(
                Expression<Func<T, bool>> predicate,
                params Expression<Func<T, object>>[] includes)
                where T : class;

            // ── Write ─────────────────────────────────────────────────────────
            Task CreateAsync<T>(T entity) where T : class;
            Task UpdateAsync<T>(T entity) where T : class;
            Task DeleteAsync<T>(T entity) where T : class;

            // ── Chat (specific DbSet exposed for SignalR history) ─────────────
            Task<IEnumerable<ChatMessage>> GetChatHistoryAsync(int complaintId);
        }
    }


