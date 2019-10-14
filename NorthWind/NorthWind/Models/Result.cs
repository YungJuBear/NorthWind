using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWind.Models
{
    public class Result
    {
        public int ResultCode { get; set; } = 200;

        public string ResultMsg { get; set; } = "";
    }
}