using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment44.Startup))]
namespace Assignment44
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
