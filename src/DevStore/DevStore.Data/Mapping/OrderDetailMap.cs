using DevStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace DevStore.Data.Mapping
{
    public class OrderDetailMap : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CarrierTrackingNumber)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("OrderDetail");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.CarrierTrackingNumber).HasColumnName("CarrierTrackingNumber");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.UnitPriceDiscount).HasColumnName("UnitPriceDiscount");
            this.Property(t => t.LineTotal).HasColumnName("LineTotal");

            // Relationships
            this.HasRequired(t => t.Order)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(d => d.OrderID);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
