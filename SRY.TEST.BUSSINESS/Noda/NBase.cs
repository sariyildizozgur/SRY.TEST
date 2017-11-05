using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using SRY.TEST.DATA;

namespace SRY.TEST.BUSSINESS.Noda
{
    public abstract class NBase<TEntity> : INRepository<TEntity> where TEntity: class, IBaseEntity
    {
        public TestContext Context { get; set; }

        protected NBase()
        {
            Context = new TestContext();
        }

        public TEntity Entity { get; set; }

        public IList<TEntity> GetAll()
        {
            var list = Context.Set<TEntity>();
            return list.ToList();
        }

        public void GetById(string id)
        {
            Entity = Context.Set<TEntity>().FirstOrDefault(p => p.Id == id);
        }

        public IList<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var result = Context.Set<TEntity>().Where(predicate);
            return result.ToList();
        }

        public TEntity Insert(TEntity entity)
        {
            try
            {
                var result = Context.Set<TEntity>().Add(entity);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual int SaveChanges()
        {
            return Context.SaveChanges();
        }

    }
   
}
