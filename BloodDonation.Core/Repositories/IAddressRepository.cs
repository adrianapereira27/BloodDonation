using BloodDonation.Core.Entities;

namespace BloodDonation.Core.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> GetByIdAsync(int id);
        Task AddAsync(Address address);
    }
}
