using NLog;
using NorthWind.Models;
using NorthWind.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace NorthWind.Models.Repository
{
    public class GenericRepository<T> : ICRUDRepository<T> where T : class
    {
        private NorthwindEntities db { get; set; }

        private static ILogger _log = LogManager.GetCurrentClassLogger();

        public GenericRepository()
        {
            db = new NorthwindEntities();
        }

        public void Create(T Content)
        {
            if (Content == null)
            {
                throw new ArgumentNullException("Content is NULL");
            }
            else
            {
                db.Set<T>().Add(Content);
                this.Save();
            }
        }

        public void Update(T Content)
        {
            if (Content == null)
            {
                throw new ArgumentNullException("Content is NULL");
            }
            else
            {
                db.Entry(Content).State = EntityState.Modified;
                this.Save();
            }
        }

        public void Delete(T Content)
        {
            if (Content == null)
            {
                throw new ArgumentNullException("Content is NULL");
            }
            else
            {
                db.Set<T>().Remove(Content);
                this.Save();
            }
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>().AsQueryable();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().FirstOrDefault(predicate);
        }

        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                _log.Fatal("{0}.{1} {2}",
                this.GetType().ToString(),
                //取得當前方法名   
                MethodBase.GetCurrentMethod().Name.ToString(),
                ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
