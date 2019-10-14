﻿using Newtonsoft.Json;
using NLog;
using NorthWind.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;

namespace NorthWind.Service
{
    public interface ICRUDRepository
    {
        Models.Result Create(object Content);
        Models.Result Update(object Content);
        Models.Result Delete(dynamic ID);
        object GetList();
        object GetEachData(dynamic ID);
        Models.Result Save();
    }

   
}