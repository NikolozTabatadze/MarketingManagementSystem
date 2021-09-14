using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.Domain.Distributors.Requests
{
    public class SearchDistributorRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal MinBonus { get; set; }
        public decimal MaxBonus { get; set; }
    }
}
