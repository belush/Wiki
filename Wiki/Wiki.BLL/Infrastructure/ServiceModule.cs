using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Wiki.DAL.Entities;
using Wiki.DAL.Interfaces;
using Wiki.DAL.Repositories;

namespace Wiki.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;

        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }
        public override void Load()
        {
            //Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(_connectionString); 
            Bind<IRepository<Record>>().To<RecordRepository>().WithConstructorArgument(_connectionString);
        }
    }
}
