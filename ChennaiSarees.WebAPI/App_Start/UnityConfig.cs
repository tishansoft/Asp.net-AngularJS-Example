using System;
using Microsoft.Practices.Unity;
using ChennaiSarees.Entities.Models;
using ChennaiSarees.Service;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using ChennaiSarees.Service.Interface;
using ChennaiSarees.Service.Implementation;
using ChennaiSarees.Infrastructure.Logging;
using ChennaiSarees.Infrastructure.Automapper;

namespace ChennaiSarees.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            container
                .RegisterType<ILogRepository, Log4NetLogger>(new PerRequestLifetimeManager())
                .RegisterType<IMappingService, MappingService>(new PerRequestLifetimeManager())
                .RegisterType<ICustomerService, CustomerService>(new PerRequestLifetimeManager())
                .RegisterType<IDataContextAsync, NorthwindContext>(new PerRequestLifetimeManager())
                .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())
                .RegisterType<IRepositoryAsync<Customer>, Repository<Customer>>(new PerRequestLifetimeManager())
                .RegisterType<IRepositoryAsync<Product>, Repository<Product>>(new PerRequestLifetimeManager())
                .RegisterType<IRepositoryAsync<Order>, Repository<Order>>(new PerRequestLifetimeManager())
                .RegisterType<IRepositoryAsync<ShoppingCart>, Repository<ShoppingCart>>(new PerRequestLifetimeManager())
                .RegisterType<IProductService, ProductService>(new PerRequestLifetimeManager())
                .RegisterType<IOrderService, OrderService>(new PerRequestLifetimeManager())
                .RegisterType<IShoppingCartService, ShoppingCartService>(new PerRequestLifetimeManager())
                .RegisterType<INorthwindStoredProcedures, NorthwindContext>(new PerRequestLifetimeManager());
        }
    }
}
