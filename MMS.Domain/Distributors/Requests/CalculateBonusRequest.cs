using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Domain.Distributors.Requests
{
    public class CalculateBonusRequest
    {
        public int DistributorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
