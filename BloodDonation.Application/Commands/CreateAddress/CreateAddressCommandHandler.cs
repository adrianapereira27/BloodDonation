using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using MediatR;

namespace BloodDonation.Application.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly IAddressRepository _addressRepository;

        public CreateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.Street, request.City, request.State,request.PostalCode, request.IdDonor);
            
            await _addressRepository.AddAsync(address);

            return address.Id;        
        }
    }
}
