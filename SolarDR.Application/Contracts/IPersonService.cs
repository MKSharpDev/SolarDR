using SolarDR.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarDR.Infrastructure.Core.Contracts
{
    public interface IPersonService
    {
        public Task<ICollection<PersonDTO>> Get(CancellationToken cancellationToken);

        public Task<PersonDTO> CreateAsync(PersonDTO newBankDto, CancellationToken cancellationToken);

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        public Task<PersonDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        public Task<PersonDTO> UpdateAsync(PersonDTO updateDto, CancellationToken cancellationToken);
    }
}
