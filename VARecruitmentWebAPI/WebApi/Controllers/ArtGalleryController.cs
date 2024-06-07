using MediatR;
using Microsoft.AspNetCore.Mvc;
using VAArtGalleryWebAPI.Application.Commands;
using VAArtGalleryWebAPI.Application.Queries;
using VAArtGalleryWebAPI.WebApi.Models;

namespace VAArtGalleryWebAPI.WebApi.Controllers
{
    [Route("api/art-galleries")]
    [ApiController]
    public class ArtGalleryController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GetAllArtGalleriesResult>>> GetAllGalleries()
        {
            var galleries = await mediator.Send(new GetAllArtGalleriesQuery());

            var result = galleries.Select(g => new GetAllArtGalleriesResult(g.Id, g.Name, g.City, g.Manager, g.ArtWorksOnDisplay?.Count ?? 0)).ToList();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CreateArtGalleryResult>> Create([FromBody] CreateArtGalleryRequest request)
        {
            var result = await mediator.Send(new CreateArtGalleryCommand(request));

            return CreatedAtAction(nameof(Create), null, new CreateArtGalleryResult(result.Id, result.Name, result.City, result.Manager));

        }


        [HttpPut("{id}")]
        public async Task<ActionResult<CreateArtGalleryResult>> Update(Guid id, [FromBody] CreateArtGalleryRequest request)
        {
            var result = await mediator.Send(new UpdateArtGalleryCommand(id, request));

            return Ok(new CreateArtGalleryResult(result.Id, result.Name, result.City, result.Manager));
        }
    }
}
