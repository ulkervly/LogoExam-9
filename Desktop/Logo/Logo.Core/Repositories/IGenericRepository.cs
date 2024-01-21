using Logo.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        public DbSet<T> Table { get; }
        Task CreatedAsync(T entity);
        void Delete(T entity);
        Task<int> CommitAsync();
        Task<T> GetByIdAsync(Expression<Func<T,bool>>? expression=null,params string[]? includes);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes);

    }
}
