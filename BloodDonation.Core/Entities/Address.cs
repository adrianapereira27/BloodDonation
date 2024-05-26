namespace BloodDonation.Core.Entities
{
    public class Address : BaseEntity
    {
        public Address(string street, string city, string state, string postalCode, int idDonor)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            IdDonor = idDonor;
        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }  // CEP
        public int IdDonor { get; private set; }  // um doador para um endereço
        public Donor Donor { get; private set; }
    }
}
