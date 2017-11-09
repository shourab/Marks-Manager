using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentResultHistoryFinder.Startup))]
namespace StudentResultHistoryFinder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
