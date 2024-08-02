using SolarDR.Domain;
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

        public async Task<PersonDTO> CreateAsync(PersonDTO newPersonDTO, CancellationToken cancellationToken)
        {
            Person newPerson = new Person()
            {
                Id = newPersonDTO.Id,
                Name = newPersonDTO.Name,
                LastName = newPersonDTO.LastName,
                Date = newPersonDTO.Date
            };

            var person = await personRepository.AddAsync(newPerson, true, cancellationToken);

            PersonDTO result = new PersonDTO()
            {
                Id = person.Id,
                Name = person.Name,
                LastName = person.LastName,
                Date = person.Date
            };
            return result;
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PersonDTO>> Get(CancellationToken cancellationToken)
        {
            var persons = await personRepository.GetAllAsync(true , cancellationToken);
            List<PersonDTO> result = new List<PersonDTO>();
            foreach (var person in persons)
            {
                PersonDTO personDTO = new PersonDTO()
                {
                    Id = person.Id,
                    Name = person.Name,
                    LastName = person.LastName,
                    Date = person.Date
                };
                result.Add(personDTO);
            }

            return result;
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
