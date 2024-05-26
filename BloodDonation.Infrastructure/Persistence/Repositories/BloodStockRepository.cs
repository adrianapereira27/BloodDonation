using BloodDonation.Core.Entities;
using BloodDonation.Core.Enums;
using BloodDonation.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infrastructure.Persistence.Repositories
{
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly BloodDonationDbContext _dbContext;

        public BloodStockRepository (BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(BloodStock bloodStock)
        {
            await _dbContext.BloodStocks.AddAsync(bloodStock);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<BloodStock>> GetAllAsync()
        {
            return await _dbContext.BloodStocks.ToListAsync();
        }

        public async Task<BloodStock> GetBloodStockByTypeAndRhFactor(BloodTypeEnum bloodType, string rhFactor)
        {
            return await _dbContext
                .BloodStocks
                .SingleOrDefaultAsync(u => u.BloodType == bloodType && u.RhFactor == rhFactor);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
