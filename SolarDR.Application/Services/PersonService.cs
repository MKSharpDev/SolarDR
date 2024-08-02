using AutoMapper;
using SolarDR.Domain;
using SolarDR.Infrastructure.Core.Contracts;

namespace SolarDR.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper) 
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public async Task<PersonDTO> CreateAsync(PersonDTO newPersonDTO, CancellationToken cancellationToken)
        {

            var person = await personRepository.AddAsync(mapper.Map<Person>(newPersonDTO), true, cancellationToken);
            return mapper.Map<PersonDTO>(person);
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PersonDTO>> Get(CancellationToken cancellationToken)
        {
            var persons = await personRepository.GetAllAsync(true , cancellationToken);
            return mapper.Map<ICollection<PersonDTO>>(persons);
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
