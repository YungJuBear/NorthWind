using Newtonsoft.Json;
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
    public interface ICRUDRepository<T>
    {
        Result Create(T Content);
        Result Update(T Content);
        Result Delete(string ID);
        object GetList();
        object GetEachData(string ID);
        Result Save();
    }
}