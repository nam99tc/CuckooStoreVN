using CuckooStore.BusinessLogicLayer;
using CuckooStore.DataAccessLayer;
using CuckooStore.Models;
using System;

using Unity;

namespace CuckooStore.Presentation
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterSingleton<CuckooDBcontext, CuckooDBcontext>();
            container.RegisterSingleton<IDbFactory, DbFactory>();
            container.RegisterSingleton<IUnitOfWork, UnitOfWork>();

            container.RegisterType<IGenericRepository<Product>, GenericRepository<Product>>();
            container.RegisterType<IProductServices, ProductServices>();

            container.RegisterType<IGenericRepository<User>, GenericRepository<User>>();
            container.RegisterType<IUserServices, UserServices>();

            container.RegisterType<IGenericRepository<Category>, GenericRepository<Category>>();
            container.RegisterType<ICategoryServices, CategoryServices>();

            container.RegisterType<IGenericRepository<Comment>, GenericRepository<Comment>>();
            container.RegisterType<ICommentServices, CommentServices>();

            container.RegisterType<IGenericRepository<Order>, GenericRepository<Order>>();
            container.RegisterType<IOrderServices, OrderServices>();

            container.RegisterType<IGenericRepository<OrderDetail>, GenericRepository<OrderDetail>>();
            container.RegisterType<IOrderDetailServices, OrderDetailServices>();

            container.RegisterType<IGenericRepository<Coupon>, GenericRepository<Coupon>>();
            container.RegisterType<ICouponServices, CouponServices>();

            container.RegisterType<IGenericRepository<Contact>, GenericRepository<Contact>>();
            container.RegisterType<IContactServices, ContactServices>();

            container.RegisterType<IGenericRepository<BallotImport>, GenericRepository<BallotImport>>();
            container.RegisterType<IBallotImportServices, BallotImportServices>();

            container.RegisterType<IGenericRepository<BallotImportDetail>, GenericRepository<BallotImportDetail>>();
            container.RegisterType<IBallotImportDetailServices, BallotImportDetailServices>();

            container.RegisterType<ICheckOutServices, CheckOutServices>();
        }
    }
}