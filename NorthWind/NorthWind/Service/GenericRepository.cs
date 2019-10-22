using NLog;
using NorthWind.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NorthWind.Service
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
            db.SaveChanges();
        }

    }
}
