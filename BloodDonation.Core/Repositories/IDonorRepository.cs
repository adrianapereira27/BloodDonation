using BloodDonation.Core.Entities;

namespace BloodDonation.Core.Repositories
{
    public interface IDonorRepository
    {
        Task<List<Donor>> GetAllAsync(string query);
        Task<Donor> GetByIdAsync(int id);
        Task AddAsync(Donor donor);

    }
}
