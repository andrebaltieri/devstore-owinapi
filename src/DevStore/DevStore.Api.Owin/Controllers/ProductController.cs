using DevStore.Data;
using DevStore.Domain;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevStore.Api.Owin.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class ProductController : ApiController
    {
        DevStoreContext db = new DevStoreContext();

        [Route("products")]
        public HttpResponseMessage GetProducts()
        {
            var result = db.Products.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("products/{number}")]
        public HttpResponseMessage GetProductsByNumber(string number)
        {
            var result = db.Products.Where(x => x.ProductNumber.ToUpper() == number.ToUpper()).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("products")]
        public HttpResponseMessage PostProduct(Product product)
        {
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Products.Add(product);
                db.SaveChanges();

                var result = product;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir produto");
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
