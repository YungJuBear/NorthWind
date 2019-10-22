using Newtonsoft.Json;
using NLog;
using NorthWind.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace NorthWind.Service
{
    public interface ICRUDRepository<T> where T : class 
    {
        void Create(T Content);
        void Update(T Content);
        void Delete(T Content);
        IQueryable<T> GetAll();
        T Get(Expression<Func<T,bool>> predicate);
        void Save();
    }
}