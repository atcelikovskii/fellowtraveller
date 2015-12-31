using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FellowTraveler.App_Start
{
    public class RegisterSevices
    {
        private static void RegisterServices(IKernel kernel)
        {
            System.Web.Mvc.DependencyResolver.SetResolver(new
            FellowTraveler.Infrastructure.NinjectDependencyResolver(kernel));
        }
    }
}