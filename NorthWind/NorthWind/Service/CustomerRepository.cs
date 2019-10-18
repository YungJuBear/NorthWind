using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using NorthWind.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace NorthWind.Service
{
    public class CustomerRepository : ICRUDRepository<Customers>, IDisposable
    {
       // delegate T Tabel<T>(T n);
        private NorthwindEntities db = new NorthwindEntities();

        private static ILogger _log = LogManager.GetCurrentClassLogger();

        public Models.Result Create(Customers customers)
        {
            if (string.IsNullOrEmpty(customers.CustomerID))
            {
                return new Result { ResultCode = 404, ResultMsg = "顧客編號不能為空。" };
            }
            if (string.IsNullOrEmpty(customers.CompanyName))
            {
                return new Result { ResultCode = 404, ResultMsg = "公司名稱不能為空。" };
            }

            db.Customers.Add(customers);

            return Save();

        }

        public Models.Result Update(Customers customers)
        {
            db.Entry(customers).State = EntityState.Modified;

            return Save();
        }

        public Models.Result Delete(string  ID)
        {

            if (string.IsNullOrEmpty(ID))
            {
                return new Result { ResultCode = 404, ResultMsg = "ID不能為空。" };
            }

            var Customer = db.Customers.Find(ID);
            if (Customer != null)
            {
                db.Customers.Remove(Customer);
                return Save();

            }

            return new Result { ResultCode = 404, ResultMsg = "找不到此ID。" };
        }

        public object GetList()
        {
            return db.Customers.ToList();
        }

        public object GetEachData(string ID)
        {
            var Customer = db.Customers.Find(ID);
            return Customer;
        }

        public Models.Result Save()
        {
            try
            {
                db.SaveChanges();
                db.Dispose();
                return new Result { ResultCode = 200, ResultMsg = "成功。" };
            }
            catch (Exception ex)
            {
                _log.Fatal("{0}.{1} {2}",
                this.GetType().ToString(),
                //取得當前方法名   
                MethodBase.GetCurrentMethod().Name.ToString(),
                ex);
                return new Result { ResultCode = 404, ResultMsg = ex.Message };
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