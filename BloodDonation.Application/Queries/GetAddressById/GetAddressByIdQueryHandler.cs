using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using BloodDonation.Infrastructure.Persistence.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetAddressById
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressDetailsViewModel>
    {
        private readonly IAddressRepository _repository;

        public GetAddressByIdQueryHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddressDetailsViewModel> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _repository.GetByIdAsync(request.Id);

            if (address == null) return null;

            var addressDetailsViewModel = new AddressDetailsViewModel(
                address.Id,
                address.Street,
                address.City,
                address.State                
                );

            return addressDetailsViewModel;
        }
    }
}
