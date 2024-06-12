using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;

namespace VAArtGalleryWebAPI.Application.Queries
{
    public class GetAllArtGalleriesByCityQuery : IRequest<List<ArtGallery>>
    {
        public GetAllArtGalleriesByCityQuery(string city)
        {
            City = city;
        }

        public string City { get; private set; }
    }
}
