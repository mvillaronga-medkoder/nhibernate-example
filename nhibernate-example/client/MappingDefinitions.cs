using System.Collections.Generic;

using Ninject;
using Ninject.Modules;

using infrastructure.dependencyResolution;

namespace client
{
    /// <summary>
    /// Defines the mappings for interfaces to objects for Ninject
    /// </summary>
    public class MappingDefinitions
    {

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            MappingDefinitions.RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var modules = new List<INinjectModule>
            {
                new ConfigModule(),
                new RepositoryModule()
            };

            kernel.Load(modules);
           
        }        
    }
}
