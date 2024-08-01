using SolarDR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarDR.Infrastructure.Core.Implemenrations
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
        { }
    }
}
