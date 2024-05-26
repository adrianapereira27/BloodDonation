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
    public class BloodStockConfiguration : IEntityTypeConfiguration<BloodStock>
    {
        public void Configure(EntityTypeBuilder<BloodStock> builder)
        {
            builder.HasKey(bs => bs.Id); // Define a propriedade Id como chave primária

            builder.Property(bs => bs.BloodType)
                .IsRequired(); // Define a propriedade BloodType como obrigatória

            builder.Property(bs => bs.RhFactor)
                .IsRequired()
                .HasMaxLength(1); // Define a propriedade RhFactor como obrigatória e com tamanho máximo de 1 caractere

            builder.Property(bs => bs.QuantityOfMl)
                .IsRequired(); // Define a propriedade QuantityOfMl como obrigatória
        }
    }
}
