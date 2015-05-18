using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;
using Ninject.Modules;

using infrastructure.interfaces;
using infrastructure.services;
using infrastructure.repositories;


namespace infrastructure.dependencyResolution
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            var configService = Kernel.Get<IConfigService>();

            //bind the repository
            Bind<IRepository>().To<NHibernateRepository>()
                .WithConstructorArgument("connectionString", configService.DbConnectionString);
            Bind<IRepositoryFactory>().To<NHibernateRepositoryFactory>();

        }
    }
}
