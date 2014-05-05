using System;
using System.Collections.Generic;

namespace DevStore.Domain
{
    public partial class Order
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public int Id { get; set; }
        public System.DateTime OrderDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public int CustomerID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
