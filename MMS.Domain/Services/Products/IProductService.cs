using MMS.Core;
using MMS.Domain.Distributors.Requests;

namespace MMS.Domain.Services.Products
{
    public interface IProductService
    {
        HttpResult Register(RegisterProductRequest request);
    }
}