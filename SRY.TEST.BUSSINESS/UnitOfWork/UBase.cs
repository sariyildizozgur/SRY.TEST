using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SRY.TEST.DATA;

namespace SRY.TEST.BUSSINESS.UnitOfWork
{
    public class UBase<TEntity> : IURepository<TEntity> where TEntity : class, IBaseEntity
    {
        public TestContext Context { get; set; }


        public UBase(TestContext context)
        {
            Context = context;
        }

        public IList<TEntity> GetAll()
        {
            var list = Context.Set<TEntity>();
            return list.ToList();
        }

        public TEntity GetById(string id)
        {
            return Context.Set<TEntity>().FirstOrDefault(p => p.Id == id);
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

      
    }
}
