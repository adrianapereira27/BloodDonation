using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using MediatR;

namespace BloodDonation.Application.Commands.CreateDonor
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, int>
    {
        private readonly IDonorRepository _donorRepository;

        public CreateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<int> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = new Donor(request.FullName, request.Email, request.BirthDate, request.Gender, request.Weight, request.BloodType, request.RhFactor, request.IdAddress, request.IdDonation);

            await _donorRepository.AddAsync(donor);

            return donor.Id; 
        }
    }
}
