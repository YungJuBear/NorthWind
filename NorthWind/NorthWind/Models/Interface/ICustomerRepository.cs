using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Models.Interface
{
    interface ICustomerRepository : ICRUDRepository<Customers>
    {
         Customers GetByID (string id);
    }
}
