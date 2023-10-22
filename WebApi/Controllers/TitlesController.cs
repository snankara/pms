using Application.Features.Departments.Queries.GetList;
using Application.Features.Titles.Commands.Create;
using Application.Features.Titles.Commands.Delete;
using Application.Features.Titles.Commands.Update;
using Application.Features.Titles.Queries.GetById;
using Application.Features.Titles.Queries.GetByName;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTitleCommand createTitleCommand)
        {
            CreatedTitleResponse response = await Mediator.Send(createTitleCommand);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteTitleCommand deleteTitleCommand = new() { Id = id };
            DeletedTitleResponse response = await Mediator.Send(deleteTitleCommand);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTitleCommand updateTitleCommand)
        {
            UpdatedTitleResponse response = await Mediator.Send(updateTitleCommand);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdTitleQuery getByIdTitleQuery = new() { Id = id };
            GetByIdTitleResponse response = await Mediator.Send(getByIdTitleQuery);
            return Ok(response);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            GetByNameTitleQuery getByNameTitleQuery = new() { Name = name };
            GetByNameTitleResponse response = await Mediator.Send(getByNameTitleQuery);
            return Ok(response);
        }
    }
}
