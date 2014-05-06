using DevStore.Api.Owin.Security;
using DevStore.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevStore.Api.Owin.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class CustomerController : ApiController
    {
        DevStoreContext db = new DevStoreContext();

        [BasicAuthenticationAttribute()]
        [Route("customers")]
        public HttpResponseMessage GetCustomersLimited(int skip, int take)
        {
            var result = db.Customers.OrderBy(x => x.FirstName).Skip(skip).Take(take).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("customers/{skip}/{take}")]
        public HttpResponseMessage GetCustomers(int skip, int take)
        {
            var result = db.Customers.OrderBy(x => x.FirstName).Skip(skip).Take(take).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("customers/{id}")]
        public HttpResponseMessage GetCustomers(int id)
        {
            var result = db.Customers.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
