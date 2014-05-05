using DevStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace DevStore.Data.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.ProductNumber)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(7);

            // Table & Column Mappings
            this.ToTable("Product");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ProductNumber).HasColumnName("ProductNumber");
        }
    }
}
