using DevStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace DevStore.Data.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(10);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.MiddleName)
                .HasMaxLength(10);

            this.Property(t => t.AccountNumber)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.AccountNumber).HasColumnName("AccountNumber");
        }
    }
}
