using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sensordatareading.Startup))]
namespace sensordatareading
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
