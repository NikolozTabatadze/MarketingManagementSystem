using MMS.Domain.Distributors;
using MMS.Domain.Distributors.Enums;


namespace MMS.Infrastructure.Db.Models
{
    public class AddressEntity
    {
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public AddresType Type { get; set; }
        public string Value { get; set; }
        public DistributorEntity Distributor { get; set; }

        public AddressEntity()
        {

        }

        public AddressEntity(Address address)
        {
            Type = address.Type;
            Value = address.Value;
        }

        public Address ToDomainModel()
        {
            return new Address
            {
                Type = Type,
                Value = Value
            };
        }
    }
}
