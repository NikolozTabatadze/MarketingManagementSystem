using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMS.Infrastructure.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Infrastructure.Db.Mappings
{
    internal class DocumentEntityMap : IEntityTypeConfiguration<DocumentEntity>
    { 
        public void Configure(EntityTypeBuilder<DocumentEntity> builder)
        {
            builder.ToTable("Document");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.DistributorId).HasColumnName("DistributorId");
            builder.Property(t => t.Type).HasColumnName("Type").IsRequired();
            builder.Property(t => t.IssueDate).HasColumnName("IssueDate");
            builder.Property(t => t.ExpireDate).HasColumnName("ExpireDate");
            builder.Property(t => t.IssuingAuthority).HasColumnName("IssuingAuthority").HasMaxLength(100);
            builder.Property(t => t.Number).HasColumnName("Number").HasMaxLength(10);
            builder.Property(t => t.PrivateNumber).HasColumnName("PrivateNumber").HasMaxLength(50);
            builder.Property(t => t.Series).HasColumnName("Series").HasMaxLength(10);

            builder.HasOne(t => t.Distributor).WithMany(t => t.Documents).HasForeignKey(t => t.DistributorId);
        }
    }
}
