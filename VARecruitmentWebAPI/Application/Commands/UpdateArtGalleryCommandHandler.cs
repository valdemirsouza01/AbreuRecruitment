using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.Domain.Interfaces;

namespace VAArtGalleryWebAPI.Application.Commands
{
    public class UpdateArtGalleryCommandHandler(IArtGalleryRepository artGalleryRepository) : IRequestHandler<UpdateArtGalleryCommand, ArtGallery>
    {
        public async Task<ArtGallery> Handle(UpdateArtGalleryCommand request, CancellationToken cancellationToken)
        {
            var artGallery = new ArtGallery(request.Data.Name, request.Data.City, request.Data.Manager, request.Id);

            return await artGalleryRepository.UpdateAsync(artGallery, cancellationToken);

        }
    }
}
