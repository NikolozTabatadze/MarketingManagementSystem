using MMS.Domain.Distributors;
using MMS.Domain.Distributors.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMS.Infrastructure.Db.Models
{
    public class DistributorEntity
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

        public List<DocumentEntity> Documents { get; set; }
        public List<ContactInfoEntity> ContactInfos { get; set; }
        public List<AddressEntity> Addresses { get; set; }
        public List<SaleEntity> Sales { get; set; } = new List<SaleEntity>();

        public DistributorEntity Recommender { get; set; }

        public DistributorEntity()
        {

        }

        public DistributorEntity(Distributor distributor)
        {
            RecommenderId = distributor?.RecommenderId;
            FirstName = distributor.FirstName;
            LastName = distributor.LastName;
            BirthDate = distributor.BirthDate;
            Gender = distributor.Gender;
            ImageUrl = distributor.ImageUrl;
            Bonus = distributor.Bonus;
            LastBonusSaleId = distributor.LastBonusSaleId;

            Documents = new List<DocumentEntity>();
            ContactInfos = new List<ContactInfoEntity>();
            Addresses = new List<AddressEntity>();
            Sales = new List<SaleEntity>();

            distributor.Documents?.ForEach(d => Documents.Add(new DocumentEntity(d)));
            distributor.ContactInfos?.ForEach(d => ContactInfos.Add(new ContactInfoEntity(d)));
            distributor.Addresses?.ForEach(d => Addresses.Add(new AddressEntity(d)));
            distributor.Sales?.ForEach(d => Sales.Add(new SaleEntity(d)));
        }

        public Distributor ToDomainModel()
        {
            return new Distributor
            {
                Id = Id,
                Documents = Documents?.Select(d => d.ToDomainModel()).ToList(),
                Addresses = Addresses?.Select(a => a.ToDomainModel()).ToList(),
                ContactInfos = ContactInfos?.Select(a => a.ToDomainModel()).ToList(),
                Sales = Sales?.Select(a => a.ToDomainModel()).ToList(),
                BirthDate = BirthDate,
                FirstName = FirstName,
                LastName = LastName,
                Gender = Gender,
                ImageUrl = ImageUrl,
                RecommenderId = RecommenderId
            };
        }
    }
}
