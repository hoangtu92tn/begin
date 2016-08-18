using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using Owin;
using ShopTu.Data;
using ShopTu.Data.Infrastructure;
using ShopTu.Data.Repositories;
using ShopTu.Model;
using ShopTu.Service;

[assembly: OwinStartup(typeof(ShopTu.Web.App_Start.Startup))]

namespace ShopTu.Web.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutoFac(app);
            ConfigureAuth(app);
        }

        public void ConfigAutoFac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
 
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<TeduShopDbContext>().AsSelf().InstancePerRequest();
            //Repositories
            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();


            //Indentity
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerDependency();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerDependency();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerDependency();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerDependency();

            //Service
            builder.RegisterAssemblyTypes(typeof(ProductService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //GlobalConfiguration.Configuration.DependencyResolver=new autofacwebap
        }
    }
}
