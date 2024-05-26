using BloodDonation.Application.ViewModels;
using MediatR;

namespace BloodDonation.Application.Queries.GetAllDonors
{
    public class GetAllDonorsQuery : IRequest<List<DonorViewModel>>
    {
        public GetAllDonorsQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
