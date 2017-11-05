using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRY.TEST.DATA;

namespace SRY.TEST.BUSSINESS.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IURepository<T> GetRepository<T>() where T : class, IBaseEntity;
        int SaveChanges();
    }
}
