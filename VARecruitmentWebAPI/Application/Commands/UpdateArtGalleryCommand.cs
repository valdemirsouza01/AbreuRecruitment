using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.WebApi.Models;

namespace VAArtGalleryWebAPI.Application.Commands
{
    public class UpdateArtGalleryCommand : IRequest<ArtGallery>
    {
        public UpdateArtGalleryCommand(Guid id, CreateArtGalleryRequest request)
        {
            Id = id;
            Data = request;
        }

        public Guid Id { get; }
        public CreateArtGalleryRequest Data { get;}
    }
}
