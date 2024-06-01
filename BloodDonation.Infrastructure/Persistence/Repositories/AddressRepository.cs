using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infrastructure.Persistence.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly BloodDonationDbContext _dbContext;

        public AddressRepository(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Address address)
        {
            await _dbContext.Addresses.AddAsync(address);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Address> GetByIdAsync(int id)
        {
            return await _dbContext.Addresses                
                .SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
