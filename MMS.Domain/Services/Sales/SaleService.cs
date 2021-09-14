using MMS.Core;
using MMS.Domain.Distributors.Repositories;
using MMS.Domain.Distributors.Requests;
using MMS.Domain.Products.Repositories;
using MMS.Domain.Sales;
using MMS.Domain.Sales.Repository;
using MMS.Domain.Sales.Request;
using MMS.Domain.Services.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.Domain.Services.Sales
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IDistributorRepository _distributorRepository;
        private readonly IProductRepository _productRepository;

        public SaleService(ISaleRepository saleRepository, 
                           IDistributorRepository distributorRepository,
                           IProductRepository productRepository)
        {
            _saleRepository = saleRepository;
            _distributorRepository = distributorRepository;
            _productRepository = productRepository;
        }
        public HttpResult Register(RegisterSaleRequest request)
        {

            if (request == null)
            {
                return HttpResult.Error("");
            }

            var distributor = _distributorRepository.GetById(request.DistributorId);
            if (distributor == null)
            {
                return HttpResult.Error("Distributor not found.");
            }

            var product = _productRepository.GetById(request.ProductId);
            if (product == null)
            {
                return HttpResult.Error("Product not found.");
            }

            var sale = new Sale()
            {
                Cost = request.Cost,
                Date = request.Date,
                Price = request.Price,
                TotalPrice = request.TotalPrice,
                Distributor = distributor,
                Product = product
            };

            _saleRepository.Insert(sale);
            return HttpResult.Success("Saled Product registered succesfully");

        }

        public HttpResult Search(SearchSaleRequest request)
        {
            var searchResult = _saleRepository.Search(request.DistributorName, request.StartDate,request.EndDate, request.ProductName);
            var result = new HttpResult();
            result.Payload.Add("data", searchResult);
            return result;
        }
    }
}
