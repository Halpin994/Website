using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration;
using Autofac.Builder;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using MvcWebsite.Logger;
using MvcWebsite.Settings;
using MvcWebsite.MessageBroker;
using MvcWebsite.HttpClientFactory;

[assembly: OwinStartupAttribute(typeof(MvcWebsite.Startup))]
namespace MvcWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // STANDARD MVC SETUP:

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //register types
            builder.RegisterType<TextLogger>().As<ILogger>().SingleInstance();
            builder.RegisterType<WebsiteSettings>().As<ISettings>().SingleInstance();
            builder.RegisterType<MessageBrokerApi>().As<IMessageBrokerApi>().SingleInstance();
            builder.RegisterType<HttpClientSimpleFactory>().As<IHttpClientSimpleFactory>().SingleInstance();

            // Run other optional steps, like registering model binders,
            // web abstractions, etc., then set the dependency resolver
            // to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // OWIN MVC SETUP:

            // Register the Autofac middleware FIRST, then the Autofac MVC middleware.
            app.UseAutofacMiddleware(container);
            //app.UseAutofacMvc();
        }
    }
}
