using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChainReaction.Startup))]
namespace ChainReaction
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
