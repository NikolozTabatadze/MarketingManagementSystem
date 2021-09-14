using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.Domain.Sales.Request
{
    public class RegisterSaleRequest
    {
        public int DistributorId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

