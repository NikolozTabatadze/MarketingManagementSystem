using MMS.Domain.Products;
using MMS.Domain.Products.Repositories;
using MMS.Infrastructure.Db;
using MMS.Infrastructure.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.Infrastructure.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }

        public Product GetById(int productId)
        {
            var entity = _db.Products.FirstOrDefault(d => d.Id == productId);
            return entity.ToDomainModel();
        }

        public int Insert(Product product)
        {
            var entity = new ProductEntity(product);
            _db.Products.Add(entity);
            _db.SaveChanges();
            return entity.Id;
        }
    }
}
