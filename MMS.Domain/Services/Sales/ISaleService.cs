using MMS.Core;
using MMS.Domain.Distributors.Requests;
using MMS.Domain.Sales.Request;

namespace MMS.Domain.Services.Sales
{
    public interface ISaleService
    {
        HttpResult Register(RegisterSaleRequest request);
        HttpResult Search(SearchSaleRequest request);
    }
}