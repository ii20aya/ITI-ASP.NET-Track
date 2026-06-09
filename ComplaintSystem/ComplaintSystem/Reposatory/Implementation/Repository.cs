using ComplaintSystem.Data;
using ComplaintSystem.Models;
using ComplaintSystem.Reposatory.Interface;
using ComplaintSystem.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComplaintSystem.Reposatory.Implementation
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _db;
        private readonly ILogger<Repository> _logger;

        public Repository(AppDbContext db, ILogger<Repository> logger)
        {
            _db = db;
            _logger = logger;
        }

        // ── Helpers ───────────────────────────────────────────────────────

        /// <summary>Returns the correct DbSet for type T.</summary>
        private DbSet<T> Set<T>() where T : class => _db.Set<T>();

        /// <summary>Applies a list of Include expressions to a query.</summary>
        private IQueryable<T> ApplyIncludes<T>(
            IQueryable<T> query,
            Expression<Func<T, object>>[] includes) where T : class
        {
            foreach (var include in includes)
                query = query.Include(include);
            return query;
        }

        // ── Read ──────────────────────────────────────────────────────────

        public async Task<IEnumerable<T>> GetAllAsync<T>(
            params Expression<Func<T, object>>[] includes) where T : class
        {
            try
            {
                return await ApplyIncludes(Set<T>().AsNoTracking(), includes)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAllAsync<{Type}> failed", typeof(T).Name);
                return Enumerable.Empty<T>();
            }
        }

        public async Task<T?> GetByIdAsync<T>(
            int id,
            params Expression<Func<T, object>>[] includes) where T : class
        {
            try
            {
                // EF Core FindAsync doesn't support Includes, so use FirstOrDefault
                var query = ApplyIncludes(Set<T>().AsNoTracking(), includes);

                // Use shadow property approach: find by primary key named "Id"
                return await query.FirstOrDefaultAsync(
                    e => EF.Property<int>(e, "Id") == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetByIdAsync<{Type}> id={Id} failed", typeof(T).Name, id);
                return null;
            }
        }

        public async Task<bool> ExistsAsync<T>(
            Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return await Set<T>().AnyAsync(predicate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ExistsAsync<{Type}> failed", typeof(T).Name);
                return false;
            }
        }

        public async Task<IEnumerable<T>> FindAsync<T>(
            Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includes) where T : class
        {
            try
            {
                var query = ApplyIncludes(Set<T>().AsNoTracking(), includes);
                return await query.Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "FindAsync<{Type}> failed", typeof(T).Name);
                return Enumerable.Empty<T>();
            }
        }

        // ── Write ─────────────────────────────────────────────────────────

        public async Task CreateAsync<T>(T entity) where T : class
        {
            await Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            Set<T>().Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        // ── Chat history ──────────────────────────────────────────────────

        public async Task<IEnumerable<ChatMessage>> GetChatHistoryAsync(int complaintId)
        {
            try
            {
                return await _db.ChatMessages
                    .Where(m => m.ComplaintId == complaintId)
                    .OrderBy(m => m.SentAt)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetChatHistoryAsync complaintId={Id} failed", complaintId);
                return Enumerable.Empty<ChatMessage>();
            }
        }
    }
}