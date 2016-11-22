using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EnergyConsumptionRationing.Models;

namespace EnergyConsumptionRationing
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Инициализация БД путем выполнения кода в классе инициализатора с использованием методов EF
            //Database.SetInitializer(new EnergyDbInitializer());

            //Инициализация Бд путем запуска SQL инструкций из файла FillDBase
            Database.SetInitializer(new EnergyDbInitializer());

            using (var db = new EnergyContext())
            {
                db.Database.Initialize(true);
            }
        }
    }
}
