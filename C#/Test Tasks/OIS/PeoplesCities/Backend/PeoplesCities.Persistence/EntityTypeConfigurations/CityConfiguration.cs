using PeoplesCities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PeoplesCities.Persistence.EntityTypeConfigurations
{
    class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(city => city.Id);
            builder.HasIndex(city => city.Id).IsUnique();
            builder.Property(city => city.Name).HasMaxLength(50).IsRequired();
            builder.Property(city => city.Description).HasMaxLength(250);
        }
    }
}
