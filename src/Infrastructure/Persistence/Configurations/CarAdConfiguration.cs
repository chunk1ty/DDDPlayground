using Domain.Aggregates.CarAdAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class CarAdConfiguration : IEntityTypeConfiguration<CarAd>
    {
        public void Configure(EntityTypeBuilder<CarAd> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.ImageUrl)
                .IsRequired()
                .HasMaxLength(2048);

            builder.Property(c => c.PricePerDay)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.IsAvailable)
                .IsRequired();

            builder.HasOne(c => c.Manufacturer)
                .WithMany()
                .HasForeignKey("ManufacturerId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey("CategoryId")
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Property<int>("_dealerId")
            //    .UsePropertyAccessMode(PropertyAccessMode.Field)
            //    .HasColumnName("DealerId")
            //    .IsRequired();

            builder.OwnsOne(c => c.Options, 
                o =>
                {
                    o.Property(op => op.NumberOfSeats);
                    o.Property(op => op.HasClimateControl);
                    o.Property(op => op.TransmissionType);
                });
        }
    }
}
