using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.Domain.Interfaces;

namespace VAArtGalleryWebAPI.Application.Queries
{
    public class GetAllArtGalleriesByCityQueryHandler(IArtGalleryRepository artGalleryRepository) : IRequestHandler<GetAllArtGalleriesByCityQuery, List<ArtGallery>>
    {
        public async Task<List<ArtGallery>> Handle(GetAllArtGalleriesByCityQuery request, CancellationToken cancellationToken)
        {
            return await artGalleryRepository.GetArtGalleryByCityAsync(request.City,cancellationToken);
        }
    }
}
