using Ninject.Modules;

using infrastructure.interfaces;
using infrastructure.services;

namespace infrastructure.dependencyResolution
{
    public class ConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigService>().To<ConfigService>();
        }

    }
}
