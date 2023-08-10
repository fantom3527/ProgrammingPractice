using Microsoft.EntityFrameworkCore;
using PeoplesCities.Application.Interfaces;
using PeoplesCities.Domain;
using PeoplesCities.Persistence.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Persistence
{
    public class PeoplesCitiesDbContext : DbContext, IUsersDbContext, ICitiesDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }

        public PeoplesCitiesDbContext(DbContextOptions<PeoplesCitiesDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration);
            base.OnModelCreating(builder);
        }
    }
}
