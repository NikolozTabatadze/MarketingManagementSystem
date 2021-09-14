using MMS.Domain.Distributors.Enums;
using MMS.Domain.Sales;
using System;
using System.Collections.Generic;

namespace MMS.Domain.Distributors
{
    public class Distributor
    {
        public int Id { get; set; }

        public int? RecommenderId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string ImageUrl { get; set; }

        public decimal Bonus { get; set; }
        public long LastBonusSaleId { get; set; }

        public List<Document> Documents { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
