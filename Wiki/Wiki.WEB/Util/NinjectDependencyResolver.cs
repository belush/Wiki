using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Wiki.BLL.DTO;
using Wiki.BLL.Interfaces;
using Wiki.BLL.Logic;

namespace Wiki.WEB.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IRecordLogic>().To<RecordLogic>();
        }
    }
}