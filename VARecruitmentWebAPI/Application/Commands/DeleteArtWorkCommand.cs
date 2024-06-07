using MediatR;

namespace VAArtGalleryWebAPI.Application.Commands
{
    public class DeleteArtWorkCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteArtWorkCommand(Guid id)
        {
            Id = id;
        }

    }
}
