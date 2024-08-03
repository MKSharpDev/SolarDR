using Microsoft.EntityFrameworkCore;
using SolarDR.Domain;
using SolarDR.Infrastructure.Core.Contracts;


namespace SolarDR.Infrastructure.Core.Implemenrations
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        private readonly AppDbContext dbContext;

        public ImageRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            dbContext = appDbContext;
        }

        public async Task<ICollection<Image>> GetAllByPersonIDAsync(Guid personId, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var result = await dbContext.Set<Image>().Where(img => img.PersonId == personId).ToListAsync(cancellationToken);
            
            return result;
        }
    }
}
