using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarDR.Application.Contracts
{
    public interface IImageService : IService<ImageDto>
    {
        public Task<ICollection<ImageDto>> GetByPersonIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
