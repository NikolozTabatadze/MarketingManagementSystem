using Microsoft.EntityFrameworkCore;
using MMS.Domain.Sales;
using MMS.Domain.Sales.Repository;
using MMS.Infrastructure.Db;
using MMS.Infrastructure.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.Infrastructure.Repositories
{
    public class SaleRepository:ISaleRepository
    {
        private readonly AppDbContext _db;

        public SaleRepository(AppDbContext db)
        {
            _db = db;
        }

        public long Insert(Sale sale)
        {
            var entity = new SaleEntity(sale);
            _db.Sales.Add(entity);
            _db.SaveChanges();
            return entity.Id;
        }

        public List<SalesSearchResultDto> Search(string distributorName, DateTime startdate, DateTime enddate, string product)
        {
            var query = _db.Sales
                .Include(s => s.Product)
                .Include(d => d.Distributor)
                .AsNoTracking();
             
            if (!string.IsNullOrEmpty(distributorName))
            {
                query = query.Where(d =>
                d.Distributor.FirstName.Contains(distributorName) ||
                d.Distributor.LastName.Contains(distributorName));

            }

            if (!string.IsNullOrEmpty(product))
            {
                query = query.Where(d =>
                d.Product.Name.Contains(product) ||
                d.Product.Code.Contains(product));

            }

            var entities = query
                .Where(d => d.Date >= startdate && d.Date <= enddate)
                .Select(s => new SalesSearchResultDto() 
                {
                    SaleId = s.Id,
                    FirstName = s.Distributor.FirstName,
                    LastName = s.Distributor.LastName,
                    Cost = s.Cost,
                    Price = s.Price,
                    ProductCode = s.Product.Code,
                    ProductName = s.Product.Name,
                    SaleDate = s.Date,
                    TotalPrice = s.TotalPrice
                })
                .ToList();
            return entities;
        }
    }
}
