using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Capstone.Web.DALs;

namespace Capstone.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        // Configure the dependency injection container.
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            // Set up the bindings
            //kernel.Bind<IInterface>.To<Class>();
            string connectionString = ConfigurationManager.ConnectionStrings["NationalParkDB"].ConnectionString;

            kernel.Bind<INationalParkDAL>().To<NationalParkDAL>().WithConstructorArgument("connectionString", connectionString);
            //kernel.Bind<INationalParkDAL>().To<MockNationalParkDAL>().WithConstructorArgument("connectionString", connectionString);

            return kernel;
        }
    }
}
