using MediatR;
using VAArtGalleryWebAPI.Domain.Interfaces;

namespace VAArtGalleryWebAPI.Application.Commands
{
    public class DeleteArtWorkCommandHandler(IArtWorkRepository artWorkRepository) : IRequestHandler<DeleteArtWorkCommand, bool>
    {
        public async Task<bool> Handle(DeleteArtWorkCommand request, CancellationToken cancellationToken)
        {
            return await artWorkRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
