using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mooshark2.Startup))]
namespace Mooshark2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
