using SolarDR.Domain;

namespace SolarDR.Infrastructure.Core.Contracts
{
    public interface IImageRepository : IRepository<Image>
    {
        Task<ICollection<Image>> GetAllByPersonIDAsync(Guid personId, bool saveChanges = true, CancellationToken cancellationToken = default);

    }
}
