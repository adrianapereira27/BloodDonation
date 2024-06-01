using BloodDonation.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonation.Infrastructure.Persistence.Configurations
{
    public class DonationConfigurations : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.HasKey(d => d.Id);

            builder
                .HasOne(d => d.Donor)
                .WithMany(p => p.Donations)
                .HasForeignKey(d => d.IdDonor)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.DonationDate)
                .IsRequired();

            builder.Property(d => d.QuantityOfMl)
                .IsRequired();
        }
    }
}
