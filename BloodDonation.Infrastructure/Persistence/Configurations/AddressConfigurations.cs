using BloodDonation.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Infrastructure.Persistence.Configurations
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.State)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(20);

            // Relacionamento um-para-um entre Donor e Address
            builder.HasOne(a => a.Donor)
                .WithOne(d => d.Address)
                .HasForeignKey<Address>(a => a.IdDonor)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
