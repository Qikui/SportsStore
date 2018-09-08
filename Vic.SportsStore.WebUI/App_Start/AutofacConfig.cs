namespace Vic.SportsStore.WebApp
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using System.Web.Mvc;
    using System;
    using global::Vic.SportsStore.Domain.Abstract;
    using global::Vic.SportsStore.Domain.Mock;
    using global::Vic.SportsStore.Domain.Concrete;

    namespace Vic.SportsStore.WebApp
    {
        public class AutofacConfig
        {
            public static void Register()
            {
                var builder = new ContainerBuilder();

                //#region moq library
                //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
                //mock.Setup(m => m.Products).Returns(new List<Product>
                //{
                //    new Product { Name = "Football", Price = 25 },
                //    new Product { Name = "Surf board", Price = 179 },
                //    new Product { Name = "Running shoes", Price = 95 }
                //});
                //builder.RegisterInstance<IProductsRepository>(mock.Object);
                //#endregion

                #region mock class
                builder.RegisterInstance<IProductRepository>(new EFProductRepository());
                #endregion
                builder.RegisterInstance<IOrderProcessor>(new EmailOrderProcessor(new EmailSettings()));
                builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies());

                var container = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }
        }
    }
}