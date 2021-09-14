using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Domain.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
