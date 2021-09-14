using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.Domain.Distributors.Requests
{
    public class SearchSaleRequest
    {
        public string DistributorName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string  ProductName { get; set; }

    }
}
