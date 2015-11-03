using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ChennaiSarees.Entities.Models.Mapping
{
    public class ShoppingCartMap : EntityTypeConfiguration<ShoppingCart>
    {
        public ShoppingCartMap()
        {
            // Primary Key
            this.HasKey(t => t.ShoppingCartId);

            // Properties
            this.Property(t => t.CustomerID)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("ShoppingCart");
            this.Property(t => t.ShoppingCartId).HasColumnName("ShoppingCartId");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.ShoppingCarts)
                .HasForeignKey(d => d.CustomerID);
            this.HasRequired(t => t.Employee)
                .WithMany(t => t.ShoppingCarts)
                .HasForeignKey(d => d.EmployeeID);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ShoppingCarts)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
