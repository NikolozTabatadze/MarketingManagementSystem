using MMS.Domain.Distributors;
using MMS.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Domain.Sales
{
    public class Sale
    {
        public long Id { get; set; }
        public Product Product { get; set; }
        public Distributor Distributor { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
