using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.ViewModels
{
    public class AddressDetailsViewModel
    {
        public AddressDetailsViewModel(int id, string street, string city, string state)
        {
            Id = id;
            Street = street;
            City = city;
            State = state;            
        }

        public int Id { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }        
    }
}
