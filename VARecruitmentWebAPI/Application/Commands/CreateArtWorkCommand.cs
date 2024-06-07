using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.WebApi.Models;

namespace VAArtGalleryWebAPI.Application.Commands
{
    public class CreateArtWorkCommand : IRequest<ArtWork>
    {
        public CreateArtWorkCommand(Guid id, CreateArtWorkRequest request)
        {
            Id = id;
            Data = request;
        }

        public Guid Id { get; set; }
        public CreateArtWorkRequest Data { get; }
  
    }
}
