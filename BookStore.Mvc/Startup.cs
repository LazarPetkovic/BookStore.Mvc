using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStore.Mvc.Startup))]
namespace BookStore.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
