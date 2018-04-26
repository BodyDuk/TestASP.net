using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmWebPortal.Startup))]
namespace FilmWebPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
