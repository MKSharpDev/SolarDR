using Microsoft.EntityFrameworkCore;
using SolarDR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarDR.Infrastructure.Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}
