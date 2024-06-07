using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.WebApi.Models;

namespace VAArtGalleryWebAPI.Application.Commands
{
    public class CreateArtGalleryCommand : IRequest<ArtGallery>
    {
        public CreateArtGalleryCommand(CreateArtGalleryRequest request)
        {
            Data = request;
        }

        public CreateArtGalleryRequest Data { get; }
  
    }
}
