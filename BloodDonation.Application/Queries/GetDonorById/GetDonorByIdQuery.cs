using BloodDonation.Application.ViewModels;
using MediatR;

namespace BloodDonation.Application.Queries.GetDonorById
{
    public class GetDonorByIdQuery : IRequest<DonorDetailsViewModel>
    {
        public GetDonorByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
