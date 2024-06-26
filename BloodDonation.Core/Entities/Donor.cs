﻿using BloodDonation.Core.Enums;

namespace BloodDonation.Core.Entities
{
    public class Donor : BaseEntity
    {        
        public Donor(string fullName, string email, DateTime birthDate, GenderEnum gender, double weight, BloodTypeEnum bloodType, string rhFactor)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;                        

            Donations = new List<Donation>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public GenderEnum Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodTypeEnum BloodType { get; private set; }
        public string RhFactor { get; private set; }                    
        public List<Donation> Donations { get; private set; }

    }
}
