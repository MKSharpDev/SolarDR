using AutoMapper;
using SolarDR.Domain;
using SolarDR.Infrastructure.Core.Contracts;

namespace SolarDR.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public PersonService(IPersonRepository personRepository) 
        {
            this.personRepository = personRepository;
        }

        public async Task<PersonDTO> CreateAsync(PersonDTO newPersonDTO, CancellationToken cancellationToken)
        {
            Person newPerson = mapper.Map<Person>(newPersonDTO);

            var person = await personRepository.AddAsync(newPerson, true, cancellationToken);

            return mapper.Map<PersonDTO>(person);
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PersonDTO>> Get(CancellationToken cancellationToken)
        {
            var person = await personRepository.GetAllAsync(true , cancellationToken);

            return mapper.Map<ICollection<PersonDTO>>(person);
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
