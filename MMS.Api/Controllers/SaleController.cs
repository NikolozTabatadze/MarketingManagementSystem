using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MMS.Core;
using MMS.Domain.Distributors.Requests;
using MMS.Domain.Sales.Request;
using MMS.Domain.Services.Sales;

namespace MMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        private readonly ILogger<DistributorController> _logger;
 
        public SaleController(ISaleService saleService,
            ILogger<DistributorController> logger)
        {
            _saleService = saleService;
            _logger = logger;
        }

        [HttpPost("register")]
        public HttpResult Register(RegisterSaleRequest request)
        {
            return _saleService.Register(request);
        }

        [HttpPost("search")]
        public HttpResult Search([FromBody]SearchSaleRequest request)
        {
            return _saleService.Search(request);
        }


    }
}
