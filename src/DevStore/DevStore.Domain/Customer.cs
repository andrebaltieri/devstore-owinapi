using System.Collections.Generic;

namespace DevStore.Domain
{
    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string AccountNumber { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
