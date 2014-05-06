using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace DevStore.Api.Owin
{
    public class DevStoreHttpConfiguration : HttpConfiguration
    {
        public DevStoreHttpConfiguration()
        {
            ConfigureRoutes();
            ConfigureJsonSerialization();
            this.EnableCors();
            this.MapHttpAttributeRoutes();
            this.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
        }

        private void ConfigureRoutes()
        {
            Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private void ConfigureJsonSerialization()
        {
            var jsonSettings = Formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;            
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
