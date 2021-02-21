using DataLayer.DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joachim_Johnson_ConsidAplication.Controllers.DataAcess.DatabasConnections
{
    public class DatabaseConection
    {
        public static CompaniesContext _CompaniesContextDB      = new CompaniesContext();
        public static StoresContext _StoreContextDB             = new StoresContext();
    }
}