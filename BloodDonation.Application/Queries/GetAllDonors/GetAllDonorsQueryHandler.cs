using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Repositories;
using MediatR;

namespace BloodDonation.Application.Queries.GetAllDonors
{
    public class GetAllDonorsQueryHandler : IRequestHandler<GetAllDonorsQuery, List<DonorViewModel>>
    {
        private readonly IDonorRepository _donorRepository;

        public GetAllDonorsQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<List<DonorViewModel>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
        {
            var donors = await _donorRepository.GetAllAsync(request.Query);

            var donorsViewModel = donors
                .Select(p => new DonorViewModel(p.Id, p.FullName, p.Email, p.BirthDate))
                .ToList();

            return donorsViewModel;
        }
    }
}
