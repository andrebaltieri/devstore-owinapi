using DevStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace DevStore.Data.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.SalesOrderNumber)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(7);

            this.Property(t => t.PurchaseOrderNumber)
                .HasMaxLength(15);

            this.Property(t => t.AccountNumber)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("Order");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.DueDate).HasColumnName("DueDate");
            this.Property(t => t.ShipDate).HasColumnName("ShipDate");
            this.Property(t => t.OnlineOrderFlag).HasColumnName("OnlineOrderFlag");
            this.Property(t => t.SalesOrderNumber).HasColumnName("SalesOrderNumber");
            this.Property(t => t.PurchaseOrderNumber).HasColumnName("PurchaseOrderNumber");
            this.Property(t => t.AccountNumber).HasColumnName("AccountNumber");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.SubTotal).HasColumnName("SubTotal");
            this.Property(t => t.TaxAmt).HasColumnName("TaxAmt");
            this.Property(t => t.Freight).HasColumnName("Freight");
            this.Property(t => t.TotalDue).HasColumnName("TotalDue");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.CustomerID);

        }
    }
}
