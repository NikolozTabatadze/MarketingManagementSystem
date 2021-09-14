using MMS.Domain.Distributors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.Domain.Sales.Repository
{
    public interface ISaleRepository
    {
        long Insert(Sale sale);
        List<SalesSearchResultDto> Search(string distributorName, DateTime startdate, DateTime enddate, string productName);
    }
}
