using MediatR;
using Microsoft.AspNetCore.Mvc;
using VAArtGalleryWebAPI.Application.Commands;
using VAArtGalleryWebAPI.Application.Queries;
using VAArtGalleryWebAPI.WebApi.Models;

namespace VAArtGalleryWebAPI.WebApi.Controllers
{
    [Route("api/art-works")]
    [ApiController]
    public class ArtWorkController(IMediator mediator) : ControllerBase
    {

        [HttpGet("{galleryId}")]
        public async Task<ActionResult<List<GetArtGalleryArtWorksResult>>> GetArtWorksByGalleryId(Guid galleryId)
        {
            var artworks = await mediator.Send(new GetArtGalleryArtWorksQuery(galleryId));

            var result = artworks.Select(g => new GetArtGalleryArtWorksResult(g.Id, g.Name, g.Author, g.CreationYear, g.AskPrice)).ToList();

            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<CreateArtWorkResult>> Create(Guid id, [FromBody] CreateArtWorkRequest request)
        {
            var result = await mediator.Send(new CreateArtWorkCommand(id, request));

            return CreatedAtAction(nameof(Create), null, new CreateArtWorkResult(result.Id, result.Name, result.Author, result.CreationYear, result.AskPrice));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await mediator.Send(new DeleteArtWorkCommand(id));

            return Ok(result);
        }
    }
}
