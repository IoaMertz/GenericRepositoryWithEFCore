using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Interfaces
{

    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey> 
    {
        void Create(TEntity entity);
        TEntity Get(TKey key);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
        void Update(TEntity entity);
        void Delete(TKey id);

        IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "");

        IEnumerable<TEntity> GetWithRawSql(string query,
       params object[] parameters);
    }

}
