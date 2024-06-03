using BloodDonation.Application.ViewModels;
using MediatR;

namespace BloodDonation.Application.Queries.GetAllDonors
{
    public class GetAllDonorsQuery : IRequest<List<DonorViewModel>>
    {        
        public string Query { get; set; }
    }
}
