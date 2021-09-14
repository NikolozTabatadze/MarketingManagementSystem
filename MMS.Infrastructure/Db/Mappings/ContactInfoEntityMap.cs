using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMS.Infrastructure.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Infrastructure.Db.Mappings
{
    internal class ContactInfoEntityMap : IEntityTypeConfiguration<ContactInfoEntity>
    { 
        public void Configure(EntityTypeBuilder<ContactInfoEntity> builder)
        {
            builder.ToTable("ContactInfo");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.DistributorId).HasColumnName("DistributorId");
            builder.Property(t => t.Type).HasColumnName("Type").IsRequired();
            builder.Property(t => t.Info).HasColumnName("Info").IsRequired().HasMaxLength(100);

            builder.HasOne(t => t.Distributor).WithMany(t => t.ContactInfos).HasForeignKey(t => t.DistributorId);
        }
    }
}
