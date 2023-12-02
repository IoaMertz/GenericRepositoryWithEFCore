using DataAcces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Classes
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class,IEntity<TKey> 
    {

        internal BaseDbContext _context { get; private set; }

        internal DbSet<TEntity> dbSet;
        public BaseRepository(BaseDbContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task Delete(TKey id)
        {
           var entityToBeDeleted =  await dbSet.FindAsync(id);
            if (entityToBeDeleted != null)
            {
                dbSet.Remove(entityToBeDeleted);
            }
        }

        public virtual async Task<TEntity> GetAsync(TKey key)
        {
            return await dbSet.FindAsync(key);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string[] includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if(includeProperties != null)
            {
                foreach(var prop in includeProperties)
                {
                    if(!String.IsNullOrEmpty(prop))
                    {
                        var property = prop.Trim();
                        query = query.Include(property);
                    }
                }
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetWithRawSqlAsync(string query, params object[] parameters)
        {
            return await dbSet.FromSqlRaw(query,parameters).ToListAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
                var entityToBeUpdated = await dbSet.FindAsync(entity.Id);
                if (entityToBeUpdated != null)
                {
                    dbSet.Update(entity);
                }
                
        }
    }
}
