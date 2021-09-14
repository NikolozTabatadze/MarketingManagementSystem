using MMS.Domain.Distributors;
using MMS.Domain.Distributors.Enums;
using System;
namespace MMS.Infrastructure.Db.Models
{
    public class DocumentEntity
    {
        public int Id { get; set; }
        public int DistributorId { get; set; }

        public string PrivateNumber { get; set; }
        public DocumentType Type { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string IssuingAuthority { get; set; }

        public DistributorEntity Distributor { get; set; }

        public DocumentEntity()
        {

        }
        public DocumentEntity(Document document)
        {
            PrivateNumber = document.PrivateNumber;
            Type = document.Type;
            Series = document.Series;
            Number = document.Number;
            IssueDate = document.IssueDate;
            ExpireDate = document.ExpireDate;
            IssuingAuthority = document.IssuingAuthority;
        }

        public Document ToDomainModel()
        {
            return new Document
            {
                Id = Id,
                PrivateNumber = PrivateNumber,
                Type = Type,
                Series = Series,
                Number = Number,
                IssueDate = IssueDate,
                ExpireDate = ExpireDate,
                IssuingAuthority = IssuingAuthority
            };
        }
        
    }  
}
