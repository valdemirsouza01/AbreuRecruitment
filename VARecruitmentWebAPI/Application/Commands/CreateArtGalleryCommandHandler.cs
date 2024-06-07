using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.Domain.Interfaces;

namespace VAArtGalleryWebAPI.Application.Commands
{
    public class CreateArtGalleryCommandHandler(IArtGalleryRepository artGalleryRepository) : IRequestHandler<CreateArtGalleryCommand, ArtGallery>
    {
        public async Task<ArtGallery> Handle(CreateArtGalleryCommand request, CancellationToken cancellationToken)
        {
            var artGallery = new ArtGallery(request.Data.Name, request.Data.City, request.Data.Manager);

            return await artGalleryRepository.CreateAsync(artGallery, cancellationToken);

        }
    }
}
