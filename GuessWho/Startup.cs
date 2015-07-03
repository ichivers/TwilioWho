using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuessWho.Startup))]
namespace GuessWho
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            SeedAzureStorage();
        }
    }
}
