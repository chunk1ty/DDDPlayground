using Domain.Aggregates.DealerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.OwnsOne(d => d.PhoneNumber,
                    p =>
                    {
                        p.Property(pn => pn.Number);
                    });

            builder.HasMany(pr => pr.CarAds)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("_carAds");
        }
    }
}
