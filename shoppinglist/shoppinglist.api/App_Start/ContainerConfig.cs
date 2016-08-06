using Autofac;
using Autofac.Integration.WebApi;
using shoppinglist.api.Repositories;
using System.Reflection;
using System.Web.Http;

namespace shoppinglist.api.App_Start
{
    public class ContainerConfig
    {
        private static IContainer _container;

        public static void SetUp()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Register repositories
            builder.RegisterType<ShoppingListRepository>().As<IShoppingListRepository>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        public static void TearDown()
        {
            _container.Dispose();
        }
    }
}