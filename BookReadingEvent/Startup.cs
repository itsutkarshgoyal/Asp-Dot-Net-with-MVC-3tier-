using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookReadingEvent.Startup))]
namespace BookReadingEvent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
