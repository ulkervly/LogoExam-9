using Logo.Core.Models;
using Logo.Core.Repositories;
using Logo.Data.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<int> CommitAsync()
        {
          return await _context.SaveChangesAsync();
        }

        public async Task CreatedAsync(T entity)
        {
           await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes)
        {
            var query = _getquery(includes);
            return expression is not null?  await query.Where(expression).ToListAsync() : await query.ToListAsync();
        }

        public  async Task<T> GetByIdAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes)
        {
            var query = _getquery(includes);
            return expression is not null ? await query.Where(expression).FirstOrDefaultAsync() : await query.FirstOrDefaultAsync();
        }
        private IQueryable<T> _getquery (params string[] includes)
        {
            var query = Table.AsQueryable();
            if (includes is not null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return query;
        }
    }
}
