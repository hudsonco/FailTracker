using FailTracker.Web.Infrastructure;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FailTracker.Web
{
    public class MvcApplication : HttpApplication
    {
        public IContainer Container
        {
            get
            {
                return HttpContext.Current.Items["_Container"] as IContainer ?? new Container();
            }
            set
            {
                HttpContext.Current.Items["_Container"] = value;
            }
        }


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Container.Configure(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(() => Container));
        }
    }
}
