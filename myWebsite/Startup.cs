using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(myWebsite.Startup))]
namespace myWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
