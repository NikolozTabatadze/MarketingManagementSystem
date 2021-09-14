using MMS.Domain.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Infrastructure.Db.Models
{
    public class SaleEntity
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public int DistributorId { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public ProductEntity Product { get; set; }
        public DistributorEntity Distributor { get; set; }

        public SaleEntity()
        {

        }

        public SaleEntity(Sale sale)
        {
            Date = sale.Date;
            Cost = sale.Cost;
            Price = sale.Price;
            TotalPrice = sale.TotalPrice;

            if (sale.Distributor != null)
            {
                DistributorId = sale.Distributor.Id;
            }
            if (sale.Product != null)
            {
                ProductId = sale.Product.Id;
            }
        }

        public Sale ToDomainModel()
        {
            return new Sale
            {
                Id = Id,
                Date = Date,
                Cost = Cost,
                Price = Price,
                TotalPrice = TotalPrice    
            };
        }
    }
}
