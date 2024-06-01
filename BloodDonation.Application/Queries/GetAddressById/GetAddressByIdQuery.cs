using BloodDonation.Application.ViewModels;
using MediatR;

namespace BloodDonation.Application.Queries.GetAddressById
{
    public class GetAddressByIdQuery : IRequest<AddressDetailsViewModel>
    {
        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
