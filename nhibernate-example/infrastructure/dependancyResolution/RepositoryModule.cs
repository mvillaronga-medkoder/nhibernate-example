using Ninject;
using Ninject.Modules;

using infrastructure.interfaces;
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
