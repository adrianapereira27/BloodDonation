using BloodDonation.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonation.Infrastructure.Persistence.Configurations
{
    public class DonorConfigurations : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .HasMany(p => p.Donations)
                .WithOne(d => d.Donor)
                .HasForeignKey(d => d.IdDonor)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
