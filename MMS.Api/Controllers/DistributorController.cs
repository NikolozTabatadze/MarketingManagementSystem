using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MMS.Core;
using MMS.Domain.Distributors.Requests;
using MMS.Domain.Services;

namespace MMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistributorController : ControllerBase
    {
        private readonly IDistributorService _distributorService;
        private readonly ILogger<DistributorController> _logger;

        public DistributorController(
            IDistributorService distributorService,
            ILogger<DistributorController> logger)
        {
            _distributorService = distributorService;
            _logger = logger;
        }

        [HttpPost("register")]
        public HttpResult Register([FromBody] RegisterDistributorRequest request)
        {
            return _distributorService.Register(request);
        }

        [HttpPost("calculate-bonus")]
        public HttpResult CalculateBonus([FromBody] CalculateBonusRequest request)
        {
            return _distributorService.CalculateBonus(request);
        }


        [HttpGet("bonus/{distributorId}")]
        public HttpResult GetBonus(int distributorId)
        {
            return _distributorService.GetBonus(distributorId);
        }

        [HttpPost("search")]
        public HttpResult Search([FromBody] SearchDistributorRequest request)
        {
            return _distributorService.Search(request);
        }

        [HttpPut("edit")]
        public HttpResult Edit([FromBody] EditDistributorRequest request)
        {
            return _distributorService.Edit(request);
        }

        [HttpDelete("delete")]
        public HttpResult Delete([FromBody] DeleteDistributorRequest request)
        {
            return _distributorService.Delete(request);
        }

    }
}
