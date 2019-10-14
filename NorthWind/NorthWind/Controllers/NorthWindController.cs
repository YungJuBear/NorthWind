using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NorthWind.Controllers
{
    public class NorthWindController : ApiController
    {
       // private const string LocalDbMasterConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True";

        //[HttpGet]
        //public IHttpActionResult Read()
        //{
        //    DataTable dataTable = new DataTable();

        //    using (SqlConnection myConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NorthWindContext"].ConnectionString))
        //    {
               

        //        string sql = @"  SELECT *
        //                         FROM [Northwind].[dbo].[Customers]";
        //        using (SqlCommand dataCommand = new SqlCommand(sql, myConn))
        //        {
        //            myConn.Open();
        //            SqlDataReader myDR = dataCommand.ExecuteReader();
        //            if (myDR.HasRows)
        //            {

        //                    dataTable.Load(myDR);
                        
        //            }
        //            myDR.Close();
        //        }
        //        myConn.Close();
        //    }
        //    var Result  = JsonConvert.SerializeObject(dataTable);
        //    return Ok(new { Result });
        //}

    }
}
