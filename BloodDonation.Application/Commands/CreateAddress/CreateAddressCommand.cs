using MediatR;

namespace BloodDonation.Application.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<int>
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int IdDonor { get; set; }

    }
}
