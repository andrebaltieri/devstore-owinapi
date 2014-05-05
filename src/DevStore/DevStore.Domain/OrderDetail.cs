namespace DevStore.Domain
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public string CarrierTrackingNumber { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
