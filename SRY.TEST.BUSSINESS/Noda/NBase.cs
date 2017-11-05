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
    /// <summary>
    /// Veri tabanı yönetimi için kullanılan base sınıfı
    /// </summary>
    /// <typeparam name="TEntity">Entity (Model tarafında karşılık gelen dbset)</typeparam>
    public abstract class NBase<TEntity> : INRepository<TEntity> where TEntity : class, IBaseEntity
    {

        #region Properties

        /// <summary>
        /// Temel Context
        /// </summary>
        public TestContext Context { get; set; }

        /// <summary>
        /// İşlem sınıfı yapılacak tablo
        /// </summary>
        public TEntity Entity { get; set; }
        #endregion

        #region Const
        
        /// <summary>
        /// Temel contex için tanımlama işlemi yapar.
        /// </summary>
        protected NBase()
        {
            Context = new TestContext();
        }

        #endregion

        #region Metod

        /// <summary>
        /// Bütün kayıtları getirme işlemi yapar.
        /// </summary>
        /// <returns></returns>
        public IList<TEntity> GetAll()
        {
            try
            {
                var list = Context.Set<TEntity>();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Kayıt doldurma işlemi yapar.
        /// </summary>
        public void Fill()
        {
            try
            {
                if (!string.IsNullOrEmpty(Entity.Id))
                    throw new Exception("Kayıt getirme işlemi için id tanımlı olmalıdır.");

                Entity = Context.Set<TEntity>().FirstOrDefault(p => p.Id == Entity.Id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Kayıt işlemi gerçekleştirir.
        /// </summary>
        public virtual void Save()
        {

            try
            {
                if (!string.IsNullOrEmpty(Entity.Id))
                {
                    Entity.Id = Guid.NewGuid().ToString();
                    Context.Set<TEntity>().Add(Entity);
                }
                else
                {
                    Context.Entry(Entity).State = EntityState.Modified;
                }

                Context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Sorgulama işlemi gerçekleştirir.
        /// </summary>
        /// <param name="predicate">Sorgulama parametresi(LINQ)</param>
        /// <returns></returns>
        public IList<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = Context.Set<TEntity>().Where(predicate);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Kayıt ekleme işlemi yapar.(Ekleme sonrası kayıt işlemi gerçekleştirmez.)
        /// </summary>
        /// <param name="entity">Entity objesi</param>
        /// <returns></returns>
        public TEntity Insert(TEntity entity)
        {
            try
            {
                var result = Context.Set<TEntity>().Add(entity);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Kayıt güncellendi mi durum bilgisini verir.
        /// </summary>
        /// <param name="entity"></param>
        public bool IsUpdate(TEntity entity)
        {
            return Context.Entry(entity).State == EntityState.Modified;
        }

        /// <summary>
        /// Kayıt silme işlemi gerçekleştirir.
        /// </summary>
        public void Delete()
        {
            try
            {
                //todo:kayıt direk silme yerine kayıt iptal durumu ileride güncelleme yapılacak.
                if (string.IsNullOrEmpty(Entity.Id))
                    throw new Exception("Silinecek tablo tanımı dolu değil.");

                Context.Set<TEntity>().Remove(Entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Genel değişikler için kayıt işlemi yapar.
        /// </summary>
        /// <returns></returns>
        public virtual int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion


    }

}
