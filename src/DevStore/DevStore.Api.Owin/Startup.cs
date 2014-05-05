using Owin;

namespace DevStore.Api.Owin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new DevStoreHttpConfiguration();
            app.UseWebApi(config);
        }
    }
}
