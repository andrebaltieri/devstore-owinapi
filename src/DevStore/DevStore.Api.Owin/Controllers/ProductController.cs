using DevStore.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevStore.Api.Owin.Controllers
{
    public class ProductController : ApiController
    {
        DevStoreContext db = new DevStoreContext();

        public HttpResponseMessage GetProducts()
        {
            var result = db.Products.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
