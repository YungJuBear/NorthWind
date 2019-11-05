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

        private readonly GenericRepository<Customers> CustomerRepository;

        public CustomersController()
        {
            CustomerRepository = new GenericRepository<Customers>();
        }
            
        // GET: api/Customers
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            return Ok(CustomerRepository.GetAll());
        }

        // GET: api/Customers/5
        [HttpGet]
        [ResponseType(typeof(Customers))]
        public IHttpActionResult GetCustomer(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            return Ok(CustomerRepository.Get(x => x.CustomerID == id));
        }

        // PUT: api/Customers/5
        [HttpPut, ActionName("Update")]
        [ResponseType(typeof(Result))]
        public IHttpActionResult PutCustomers([FromBody]Customers Customer)
        {
            if (string.IsNullOrEmpty(Customer.CustomerID))
            {
                return NotFound();
            }
            else if (string.IsNullOrEmpty(Customer.CompanyName))
            {
                return BadRequest("公司名稱不能為空。");
            }

             CustomerRepository.Update(Customer);

            return Ok();
        }

        // POST: api/Customers
        [HttpPost, ActionName("Create")]
        [ResponseType(typeof(Result))]
        public IHttpActionResult PostCustomers([FromBody]Customers Customer)
        {
            if (string.IsNullOrEmpty(Customer.CustomerID))
            {
                return NotFound();
            }
            else if (string.IsNullOrEmpty(Customer.CompanyName))
            {
                return BadRequest("公司名稱不能為空。");
            }

           CustomerRepository.Create(Customer);

            return Ok();
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Result))]
        [HttpDelete, ActionName("Delete")]
        public IHttpActionResult DeleteCustomers(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            Customers customers =  CustomerRepository.Get(x => x.CustomerID == id);

            if (customers.Equals(null))
            {
                return BadRequest("找不到此顧客資料。");
            }

            CustomerRepository.Delete(customers);

            return Ok();
        }

    }
}