using System.Collections.Generic;

namespace DevStore.Domain
{
    public partial class Product
    {
        public Product()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
