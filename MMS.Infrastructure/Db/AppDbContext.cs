using Microsoft.EntityFrameworkCore;
using MMS.Infrastructure.Db.Mappings;
using MMS.Infrastructure.Db.Models;

namespace MMS.Infrastructure.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<ContactInfoEntity> ContactInfos { get; set; }
        public DbSet<DistributorEntity> Distributors { get; set; }
        public DbSet<DocumentEntity> Documents { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<SaleEntity> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressEntityMap());
            modelBuilder.ApplyConfiguration(new ContactInfoEntityMap());
            modelBuilder.ApplyConfiguration(new DistributorEntityMap());
            modelBuilder.ApplyConfiguration(new DocumentEntityMap());
            modelBuilder.ApplyConfiguration(new ProductEntityMap());
            modelBuilder.ApplyConfiguration(new SaleEntityMap());



            base.OnModelCreating(modelBuilder);
        }
    }
}
