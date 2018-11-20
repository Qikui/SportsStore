namespace Vic.SportsStore.WebApp
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using System.Web.Mvc;
    using System;
    using global::Vic.SportsStore.Domain.Abstract;
    using global::Vic.SportsStore.Domain.Mock;
    using global::Vic.SportsStore.Domain.Concrete;
    using global::Vic.SportsStore.WebApp.Infrastructure.Abstract;
    using global::Vic.SportsStore.WebApp.Infrastructure.Concrete;

    namespace Vic.SportsStore.WebApp
    {
        public class AutofacConfig
        {
            public static void Register()
            {
                //var builder = new ContainerBuilder();

                ////#region moq library
                ////Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
                ////mock.Setup(m => m.Products).Returns(new List<Product>
                ////{
                ////    new Product { Name = "Football", Price = 25 },
                ////    new Product { Name = "Surf board", Price = 179 },
                ////    new Product { Name = "Running shoes", Price = 95 }
                ////});
                ////builder.RegisterInstance<IProductsRepository>(mock.Object);
                ////#endregion

                //#region mock class
                //builder.RegisterInstance<IProductRepository>(new EFProductRepository());
                //#endregion
                //builder.RegisterInstance<IOrderProcessor>(new EmailOrderProcessor(new EmailSettings()));
                //builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies());
                //builder.RegisterInstance<IAuthProvider>(new FormsAuthProvider());

                //builder.RegisterInstance<IAuthProvider>(new FormsAuthProvider()).PropertiesAutowired();//
                //builder.RegisterType<EFDbContext>().SingleInstance().PropertiesAutowired();     //property NInget
                //var container = builder.Build();
                //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
                var builder = new ContainerBuilder();

                builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies());

                builder.RegisterInstance<IProductRepository>(new EFProductRepository())
                    .PropertiesAutowired();

                builder.RegisterInstance<IOrderProcessor>(new EmailOrderProcessor(new EmailSettings()));

                builder
                    .RegisterInstance<IAuthProvider>(new FormsAuthProvider())
                    .PropertiesAutowired();

                builder
                    .RegisterType<EFDbContext>()
                    .SingleInstance();

                var container = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }
        }
    }
}