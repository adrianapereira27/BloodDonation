using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Repositories;
using MediatR;

namespace BloodDonation.Application.Queries.GetDonorById
{
    public class GetDonorByIdQueryHandler : IRequestHandler<GetDonorByIdQuery, DonorDetailsViewModel>
    {
        private readonly IDonorRepository _donorRepository;

        public GetDonorByIdQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<DonorDetailsViewModel> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetByIdAsync(request.Id);

            if (donor == null) return null;

            var donorDetailsViewModel = new DonorDetailsViewModel(
                donor.Id,
                donor.FullName,
                donor.Email,                
                donor.Gender,
                donor.Weight,                
                donor.BloodType,
                donor.RhFactor,
                donor.Donation.DonationDate
                );

            return donorDetailsViewModel;
        }
    }
}
