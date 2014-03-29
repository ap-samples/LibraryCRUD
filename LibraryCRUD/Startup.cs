using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryCRUD.Startup))]
namespace LibraryCRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
