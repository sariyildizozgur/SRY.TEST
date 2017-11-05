using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRY.TEST.DATA;

namespace SRY.TEST.BUSSINESS.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private TestContext _context;
        private bool Disposed = false;

        public TestContext Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public UnitOfWork()
        {
            _context = new TestContext();
        }

        public IURepository<T> GetRepository<T>() where T : class, IBaseEntity
        {
            return new UBase<T>(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
      
        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.Disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
