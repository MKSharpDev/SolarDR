using SolarDR.Infrastructure.Core.Contracts;

namespace SolarDR.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;

        public PersonService(IPersonRepository personRepository) 
        {
            this.personRepository = personRepository;
        }

        public Task<PersonDTO> CreateAsync(PersonDTO newBankDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PersonDTO>> Get(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> UpdateAsync(PersonDTO updateDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
