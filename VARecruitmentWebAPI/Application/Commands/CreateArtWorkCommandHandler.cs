using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.Domain.Interfaces;

namespace VAArtGalleryWebAPI.Application.Commands
{
    public class CreateArtWorkCommandHandler(IArtWorkRepository artWorkRepository) : IRequestHandler<CreateArtWorkCommand, ArtWork>
    {
        public async Task<ArtWork> Handle(CreateArtWorkCommand request, CancellationToken cancellationToken)
        {
            var artWorks = new ArtWork(request.Data.Name, request.Data.Author, request.Data.CreationYear, request.Data.AskPrice);

            return await artWorkRepository.CreateAsync(request.Id, artWorks, cancellationToken);

        }
    }
}
