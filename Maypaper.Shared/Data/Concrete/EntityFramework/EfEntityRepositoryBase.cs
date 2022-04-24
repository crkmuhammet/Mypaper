using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Maypaper.Shared.Data.Abstract;
using Maypaper.Shared.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Maypaper.Shared.Data.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity:class,IEntity,new()
    {
        private readonly DbContext _context;

        // Constructor
        public EfEntityRepositoryBase(DbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            // Remove Async olmadığı için bizim kendimiz oluşturmamız gerekiyor.
            await Task.Run(() => { _context.Set<TEntity>().Remove(entity); });
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            // Bu kısma gelen predicate'in null olma durumu da var.
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicate!=null)
            {
                query = query.Where(predicate);
            }
            // includeProperties içinde değerler var ise foreach ile dönerek query'i içine ekleyeceğiz.
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            // Bu kısma gelen predicate'in null olma durumu da var.
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            // includeProperties içinde değerler var ise foreach ile dönerek query'i içine ekleyeceğiz.
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            // Update Async olmadığı için bizim kendimiz oluşturmamız gerekiyor.
            await Task.Run(() => { _context.Set<TEntity>().Update(entity); });
        }
    }
}
