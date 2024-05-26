using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infrastructure.Persistence.Repositories
{    
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodDonationDbContext _dbContext;

        public DonorRepository(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Donor donor)
        {
            await _dbContext.Donors.AddAsync(donor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Donor>> GetAllAsync(string query)
        {
            IQueryable<Donor> donors = _dbContext.Donors;

            if (!string.IsNullOrWhiteSpace(query))
            {
                donors = donors.Where(p => p.FullName.Contains(query) || 
                p.Donation.DonationDate.Contains(query));
            }

            return await _dbContext.Donors.ToListAsync();
        }
                
        public async Task<Donor> GetByIdAsync(int id)
        {
            return await _dbContext.Donors
                .Include(d => d.Donations)  // consultando tbm as doações do doador
                .SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
