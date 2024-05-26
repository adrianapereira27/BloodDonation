namespace BloodDonation.Core.Entities
{
    public class Donation : BaseEntity
    {
        public Donation(string donationDate, int quantityOfMl, int idDonor)
        {           
            DonationDate = donationDate;
            QuantityOfMl = quantityOfMl;
            IdDonor = idDonor;
        }
               
        public string DonationDate { get; private set; }
        public int QuantityOfMl { get; private set; }
        public int IdDonor { get; private set; }
        public Donor Donor { get; private set; }
    }
}
