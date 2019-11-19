using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using NorthWind.Models;
using NorthWind.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NorthWind.Models.Repository
{
    public class CustomerRepository : GenericRepository<Customers>,ICustomerRepository
    {
        private NorthwindEntities db { get; set; }

        private static ILogger _log = LogManager.GetCurrentClassLogger();

        public Customers GetByID(string id)
        {
            return this.Get(x => x.CustomerID == id);
        }

    }
}