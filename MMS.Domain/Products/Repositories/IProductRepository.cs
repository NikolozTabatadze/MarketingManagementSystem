using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.Domain.Products.Repositories
{
    public interface IProductRepository
    {
        int Insert(Product product);
        Product GetById(int productId);
    }
}
