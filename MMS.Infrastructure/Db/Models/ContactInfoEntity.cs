using MMS.Domain.Distributors;
using MMS.Domain.Distributors.Enums;

namespace MMS.Infrastructure.Db.Models
{
    public class ContactInfoEntity
    {
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public ContactType Type { get; set; }
        public string Info { get; set; }

        public DistributorEntity Distributor { get; set; }

        public ContactInfoEntity()
        {

        }
        public ContactInfoEntity(ContactInfo contactInfo)
        {
            Type = contactInfo.Type;
            Info = contactInfo.Info;
        }

        public ContactInfo ToDomainModel()
        {
            return new ContactInfo
            {
                Type = Type,
                Info = Info
            };
        }
    }
}
