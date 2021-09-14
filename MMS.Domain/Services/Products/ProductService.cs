using MMS.Core;
using MMS.Domain.Distributors.Requests;
using MMS.Domain.Products;
using MMS.Domain.Products.Repositories;


namespace MMS.Domain.Services.Products
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository  productRepository)
        {
           _productRepository = productRepository;
        }
        public HttpResult Register(RegisterProductRequest request)
        {
            if (request == null)
            {
                return HttpResult.Error("");
            }

            var product = new Product
            {
                Name = request.Name,
                Code = request.Code,
                Price = request.Price
            };

            _productRepository.Insert(product);
            return HttpResult.Success("Product registered succesfully");
        }
    }
}
