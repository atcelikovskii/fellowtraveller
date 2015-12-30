using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DataService;

namespace FellowTraveler
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Context.Application["DataService"] = new DataServiceRAM();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
