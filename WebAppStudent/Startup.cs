using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppStudent.Startup))]
namespace WebAppStudent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
