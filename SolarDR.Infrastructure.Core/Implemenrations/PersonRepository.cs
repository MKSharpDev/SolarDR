using SolarDR.Domain;
using SolarDR.Infrastructure.Core.Contracts;

namespace SolarDR.Infrastructure.Core.Implemenrations
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
        { }
    }
}
