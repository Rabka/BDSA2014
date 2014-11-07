using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment44.Startup))]
namespace Assignment44
{
    public partial class Startup
    {
        /// <summary>
        /// We haven't been able to remove this method and class for some reason.
        /// The program will stop working if we do that.
        /// An explanation in the feedback would be appreciated.
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
