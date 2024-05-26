using BloodDonation.Core.Entities;
using BloodDonation.Core.Enums;

namespace BloodDonation.Core.Repositories
{
    public interface IBloodStockRepository
    {
        Task<List<BloodStock>> GetAllAsync();
        Task<BloodStock> GetBloodStockByTypeAndRhFactor(BloodTypeEnum bloodType, string rhFactor);
        Task AddAsync(BloodStock bloodStock);
        Task SaveChangesAsync();
    }
}
