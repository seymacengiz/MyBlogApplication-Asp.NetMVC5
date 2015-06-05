using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogSeymaCengiz.Startup))]
namespace BlogSeymaCengiz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
