﻿using MMS.Core;
using MMS.Domain.Distributors.Enums;
using System;
using System.Collections.Generic;

namespace MMS.Domain.Distributors.Requests
{
    public class RegisterDistributorRequest
    {
        public int Id { get; set; }

        public int? RecommenderId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string ImageUrl { get; set; }

        public List<Document> Documents { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
