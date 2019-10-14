using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;
using NLog;
using NorthWind.Models;
using NorthWind.Service;

namespace NorthWind.Controllers
{
    public class CustomersController : ApiController
    {
        private static ILogger _log = LogManager.GetCurrentClassLogger();

        private readonly ICRUDRepository  CustomerRepository;

        public CustomersController()
        {
            CustomerRepository = new CustomerRepository();
        }
            
        // GET: api/Customers
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            return Ok(CustomerRepository.GetList());
        }

        // GET: api/Customers/5
        [HttpGet]
        [ResponseType(typeof(Customers))]
        public IHttpActionResult GetCustomers(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Ok(new Result { ResultCode = 404, ResultMsg = "id不能為空。" });
            }
            return Ok(CustomerRepository.GetEachData(id));
        }

        // PUT: api/Customers/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomers([FromBody]Models.Customers Customer)
        {
            if (string.IsNullOrEmpty(Customer.CustomerID))
            {
                return Ok(new Result { ResultCode = 404, ResultMsg = "顧客編號不能為空。" });
            }
            if (string.IsNullOrEmpty(Customer.CompanyName))
            {
                return Ok(new Result { ResultCode = 404, ResultMsg = "公司名稱不能為空。" });
            }

            var Result = CustomerRepository.Update(Customer);

            return Ok(Result);
        }

        // POST: api/Customers
        [HttpPost]
        [ResponseType(typeof(Customers))]
        public IHttpActionResult PostCustomers([FromBody]Models.Customers Customer)
        {
            if (string.IsNullOrEmpty(Customer.CustomerID))
            {
                return Ok(new Result { ResultCode = 404, ResultMsg = "顧客編號不能為空。" });
            }
            if (string.IsNullOrEmpty(Customer.CompanyName))
            {
                return Ok (new Result { ResultCode = 404, ResultMsg = "公司名稱不能為空。" });
            }

            var Result = CustomerRepository.Create(Customer);

            return Ok(Result);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customers))]
        public IHttpActionResult DeleteCustomers(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Ok(new Result { ResultCode = 404, ResultMsg = "id不能為空。" });
            }

            var Result = CustomerRepository.Delete(id);

            return Ok(Result);
        }
    }
}