using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.Domain.Sales
{
    public class SalesSearchResultDto
    {
        public long SaleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }


    }
}
