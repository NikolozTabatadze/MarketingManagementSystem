using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMS.Infrastructure.Db.Models;

namespace MMS.Infrastructure.Db.Mappings
{
    internal class SaleEntityMap : IEntityTypeConfiguration<SaleEntity>
    { 
        public void Configure(EntityTypeBuilder<SaleEntity> builder)
        {
            builder.ToTable("Sale");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.DistributorId).HasColumnName("DistributorId");
            builder.Property(t => t.ProductId).HasColumnName("ProductId");
            builder.Property(t => t.Date).HasColumnName("Date");
            builder.Property(t => t.Cost).HasColumnName("Cost");
            builder.Property(t => t.Price).HasColumnName("Price");
            builder.Property(t => t.TotalPrice).HasColumnName("TotalPrice");

            builder.HasOne(t => t.Distributor).WithMany(t => t.Sales).HasForeignKey(t => t.DistributorId);
            builder.HasOne(t => t.Product).WithMany().HasForeignKey(t => t.ProductId);
        }
    }
}
