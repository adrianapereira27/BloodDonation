using BloodDonation.Core.Enums;

namespace BloodDonation.Application.ViewModels
{
    public class DonorDetailsViewModel
    {
        public DonorDetailsViewModel(int id, string fullName, string email, GenderEnum gender, double weight, BloodTypeEnum bloodType, string rhFactor)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;            
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public GenderEnum Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodTypeEnum BloodType { get; private set; }
        public string RhFactor { get; private set; }        
    }
}
