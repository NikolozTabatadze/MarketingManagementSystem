using MMS.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Infrastructure.Db.Models
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ProductEntity()
        {

        }
        public ProductEntity(Product product)
        {
            Code = product.Code;
            Name = product.Name;
            Price = product.Price;
        }

        public Product ToDomainModel()
        {
            return new Product
            {
                Id = Id,
                Code = Code,
                Name = Name,
                Price = Price
            };
        }
    }
}
