using BloodDonation.Core.Enums;
using MediatR;

namespace BloodDonation.Application.Commands.CreateDonor
{
    public class CreateDonorCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public double Weight { get; set; }
        public BloodTypeEnum BloodType { get; set; }
        public string RhFactor { get; set; }
        public int IdAddress { get; set; }
        public int IdDonation { get; set; }
    }
}
