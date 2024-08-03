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

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var personFromDb = await personRepository.GetAsync(id, true, cancellationToken);
            if (personFromDb == null)
            {
                throw new Exception("Нет человека с таким id");
            }

            await personRepository.DeleteAsync(id, true, cancellationToken);
        }

        public async Task<ICollection<PersonDTO>> Get(CancellationToken cancellationToken)
        {
            var persons = await personRepository.GetAllAsync(true , cancellationToken);
            return mapper.Map<ICollection<PersonDTO>>(persons);
        }

        public async Task<PersonDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var personFromDb = await personRepository.GetAsync(id, true, cancellationToken);
            if (personFromDb == null)
            {
                throw new Exception("Нет человека с таким id");
            }

            return mapper.Map<PersonDTO>(personFromDb);
        }

        public async Task<PersonDTO> UpdateAsync(PersonDTO updateDto, CancellationToken cancellationToken)
        {
            var personFromDb = await personRepository.GetAsync(updateDto.Id , true, cancellationToken);
            if (personFromDb == null)
            {
                throw new Exception("Нет человека с таким id");
            }

            await personRepository.EditAsync(mapper.Map<Person>(updateDto), true, cancellationToken);

            var result = await personRepository.GetAsync(updateDto.Id, true, cancellationToken);

            return mapper.Map<PersonDTO>(result);
        }
    }
}
