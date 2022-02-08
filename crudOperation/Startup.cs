using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(crudOperation.Startup))]
namespace crudOperation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
