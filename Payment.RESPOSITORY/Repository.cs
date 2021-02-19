using Microsoft.EntityFrameworkCore;
using Payment.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Payment.RESPOSITORY
{
   

    public class Repository<TEntity> where TEntity : class
    {
        internal PaymentDbContext _context;
        internal DbSet<TEntity> dbSet;

        public Repository(PaymentDbContext context)
        {
            this._context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
    }
}
