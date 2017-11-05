using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SRY.TEST.DATA;

namespace SRY.TEST.BUSSINESS.GenericRepository
{
    /// <summary>
    /// Base class için temel alınacak interface classı.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : IBaseEntity
    {
        IList<TEntity> GetAll();
        TEntity GetById(string id);
        IList<TEntity> Where(Expression<Func<TEntity,bool>> predicate);
        TEntity Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
