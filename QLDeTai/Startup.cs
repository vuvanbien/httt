using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLDeTai.Startup))]
namespace QLDeTai
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
