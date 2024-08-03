using AutoMapper;
using SolarDR.Application.Contracts;
using SolarDR.Domain;
using SolarDR.Infrastructure.Core.Contracts;
using SolarDR.Infrastructure.Core.Implemenrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarDR.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;
        private readonly IMapper mapper;

        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }

        public async Task<ImageDto> CreateAsync(ImageDto newDto, CancellationToken cancellationToken)
        {
            var image = await imageRepository.AddAsync(mapper.Map<Image>(newDto), true, cancellationToken);
            return mapper.Map<ImageDto>(image);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {

            var personFromDb = await imageRepository.GetAsync(id, true, cancellationToken);
            if (personFromDb == null)
            {
                throw new Exception("Нет картини с таким id");
            }

            await imageRepository.DeleteAsync(id, true, cancellationToken);
        }

        public async Task<ICollection<ImageDto>> Get(CancellationToken cancellationToken)
        {
            var imageFromDb = await imageRepository.GetAllAsync(true, cancellationToken);

            return mapper.Map<ICollection<ImageDto>>(imageFromDb);
        }

        public async Task<ImageDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var imageFromDb = await imageRepository.GetAsync(id, true, cancellationToken);
            if (imageFromDb == null)
            {
                throw new Exception("Нет картинки с таким id");
            }

            return mapper.Map<ImageDto>(imageFromDb);
        }

        public async Task<ICollection<ImageDto>> GetByPersonIdAsync(Guid personId, CancellationToken cancellationToken)
        {
            var imageFromDb = await imageRepository.GetAllByPersonIDAsync(personId, true, cancellationToken);

            return mapper.Map<ICollection<ImageDto>>(imageFromDb);
        }

        public Task<ImageDto> UpdateAsync(ImageDto updateDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
