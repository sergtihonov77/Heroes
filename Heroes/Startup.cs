using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Heroes.Startup))]
namespace Heroes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
