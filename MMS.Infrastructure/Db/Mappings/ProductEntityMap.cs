using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMS.Infrastructure.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Infrastructure.Db.Mappings
{
    internal class ProductEntityMap : IEntityTypeConfiguration<ProductEntity>
    { 
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.Code).HasColumnName("Code");
            builder.Property(t => t.Name).HasColumnName("Name");
            builder.Property(t => t.Price).HasColumnName("Price");
        }
    }
}
