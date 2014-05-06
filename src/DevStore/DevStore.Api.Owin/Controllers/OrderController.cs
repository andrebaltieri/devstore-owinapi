using DevStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DevStore.Api.Owin.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class OrderController : ApiController
    {
        DevStoreContext db = new DevStoreContext();

        [Route("orders")]
        public HttpResponseMessage GetOrders(int skip, int take)
        {
            var result = db.Orders.OrderBy(x => x.SalesOrderNumber).Skip(skip).Take(take).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("orders/{id}/details")]
        public HttpResponseMessage GetOrders(int id)
        {
            var result = db.OrderDetails.Include("Product").Where(x => x.OrderID == id).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
