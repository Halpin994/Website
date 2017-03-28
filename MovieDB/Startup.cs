using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieDB.Startup))]
namespace MovieDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
