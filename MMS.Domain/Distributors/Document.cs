using MMS.Domain.Distributors.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Domain.Distributors
{
    public class Document
    {
        public int Id { get; set; }
        public string PrivateNumber { get; set; }
        public DocumentType Type { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string IssuingAuthority { get; set; }
    }
}
