using BloodDonation.Core.Entities;
using BloodDonation.Core.Enums;
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

            builder.Property(d => d.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.BirthDate)
                .IsRequired();

            builder.Property(d => d.Gender)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (GenderEnum)Enum.Parse(typeof(GenderEnum), v)
                );

            builder.Property(d => d.Weight)
                .IsRequired();

            builder.Property(d => d.BloodType)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (BloodTypeEnum)Enum.Parse(typeof(BloodTypeEnum), v)
                );

            builder.Property(d => d.RhFactor)
                .IsRequired()
                .HasMaxLength(3);
                        
        }
    }
}
