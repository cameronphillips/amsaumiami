using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(memberDatabasetest.Startup))]
namespace memberDatabasetest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
