using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FellowTraveler.Infrastructure
{
    public static class DataServiceControllerExtension
    {
        public static IDataService GetDataService(this Controller ctrl)
        {
            return (IDataService)ctrl.HttpContext.Application["DataService"];
        }
    }
}