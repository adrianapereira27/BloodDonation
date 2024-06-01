using BloodDonation.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            // Definindo o relacionamento com a entidade Donor
            builder.HasOne(a => a.Donor)
                .WithMany()  // Relacionamento One-to-Many ou Many-to-One (ajuste conforme necessário)
                .HasForeignKey(a => a.IdDonor)
                .OnDelete(DeleteBehavior.Cascade);  // Configurando a exclusão em cascata

        }
    }
}
