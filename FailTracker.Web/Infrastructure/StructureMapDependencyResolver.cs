using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FailTracker.Web.Infrastructure
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private Func<IContainer> _factory;

        public StructureMapDependencyResolver(Func<IContainer> factory)
        {
            _factory = factory;
        }
        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
