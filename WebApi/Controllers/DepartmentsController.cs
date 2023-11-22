using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Delete;
using Application.Features.Departments.Commands.Update;
using Application.Features.Departments.Queries.GetById;
using Application.Features.Departments.Queries.GetCount;
using Application.Features.Departments.Queries.GetList;
using Application.Features.Titles.Commands.Create;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDepartmentCommand createDepartmentCommand)
        {
            CreatedDepartmentResponse response = await Mediator.Send(createDepartmentCommand);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteDepartmentCommand deleteDepartmentCommand =  new() { Id = id};
            DeletedDepartmentResponse response = await Mediator.Send(deleteDepartmentCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListDepartmentQuery getListDepartmentQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListDepartmentListItemDto> response = await Mediator.Send(getListDepartmentQuery);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDepartmentCommand updateDepartmentCommand)
        {
            UpdatedDepartmentResponse response = await Mediator.Send(updateDepartmentCommand);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBydId([FromRoute] Guid id)
        {
            GetByIdDepartmentQuery getByIdDepartmentQuery = new() { Id = id };
            GetByIdDepartmentResponse response = await Mediator.Send(getByIdDepartmentQuery);

            return Ok(response);
        }

        [HttpGet("GetCount")]
        public async Task<IActionResult> GetCount()
        {
            GetCountDepartmentResponse response = await Mediator.Send(new GetCountDepartmentQuery());
            return Ok(response);
        }
    }
}
