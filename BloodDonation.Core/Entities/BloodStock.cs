using BloodDonation.Core.Enums;

namespace BloodDonation.Core.Entities
{
    public class BloodStock : BaseEntity
    {
        public BloodStock(BloodTypeEnum bloodType, string rhFactor, int quantityOfMl)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityOfMl = quantityOfMl;
        }

        public BloodTypeEnum BloodType { get; private set; }
        public string RhFactor { get; private set; }
        public int QuantityOfMl { get; private set; }
    }
}
