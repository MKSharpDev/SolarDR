using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarDR.Application.Contracts
{
    public interface IService<T> where T : class
    {
        public Task<ICollection<T>> Get(CancellationToken cancellationToken);

        public Task<T> CreateAsync(T newDto, CancellationToken cancellationToken);

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        public Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        public Task<T> UpdateAsync(T updateDto, CancellationToken cancellationToken);
    }
}

