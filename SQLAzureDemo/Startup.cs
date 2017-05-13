using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SQLAzureDemo.Startup))]
namespace SQLAzureDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
