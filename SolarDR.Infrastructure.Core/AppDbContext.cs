using Microsoft.EntityFrameworkCore;
using SolarDR.Domain;

namespace SolarDR.Infrastructure.Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}
