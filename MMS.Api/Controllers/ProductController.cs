using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MMS.Core;
using MMS.Domain.Distributors.Requests;
using MMS.Domain.Services;
using MMS.Domain.Services.Products;

namespace MMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService,
            ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpPost("register")]
        public HttpResult Register([FromBody] RegisterProductRequest request)
        {
            return _productService.Register(request);
        }



    }
}
