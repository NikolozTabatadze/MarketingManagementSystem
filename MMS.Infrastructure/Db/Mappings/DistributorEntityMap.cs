using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMS.Infrastructure.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Infrastructure.Db.Mappings
{
    internal class DistributorEntityMap : IEntityTypeConfiguration<DistributorEntity>
    { 
        public void Configure(EntityTypeBuilder<DistributorEntity> builder)
        {
            builder.ToTable("Distributor");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.BirthDate).HasColumnName("BirthDate").IsRequired();
            builder.Property(t => t.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(50);
            builder.Property(t => t.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(50);
            builder.Property(t => t.ImageUrl).HasColumnName("ImageUrl").IsRequired();
            builder.Property(t => t.Gender).HasColumnName("Gender").IsRequired();
            builder.Property(t => t.RecommenderId).HasColumnName("RecommenderId").IsRequired(false);

            builder.HasOne(t => t.Recommender).WithMany().HasForeignKey(t => t.RecommenderId);
        }
    }
}
