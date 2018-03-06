using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NaturalWebDesigns.Startup))]
namespace NaturalWebDesigns
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
