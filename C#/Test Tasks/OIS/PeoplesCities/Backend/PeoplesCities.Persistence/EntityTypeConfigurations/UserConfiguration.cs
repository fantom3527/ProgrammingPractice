using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PeoplesCities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Persistence.EntityTypeConfigurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(city => city.Id);
            builder.HasIndex(city => city.Id).IsUnique();
            builder.Property(city => city.Name).HasMaxLength(50).IsRequired();
            builder.Property(city => city.Email).HasMaxLength(50);
        }
    }
}
