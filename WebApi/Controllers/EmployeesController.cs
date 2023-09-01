using Application.Features.Employees.Commands.Create;
using Application.Features.Employees.Commands.Delete;
using Application.Features.Employees.Commands.Update;
using Application.Features.Employees.Queries.GetById;
using Application.Features.Employees.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateEmployeeCommand createEmployeeCommand)
        {
            CreatedEmployeeResponse response = await Mediator.Send(createEmployeeCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListEmployeeQuery getListEmployeeQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListEmployeeListItemDto> response = await Mediator.Send(getListEmployeeQuery);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdEmployeeQuery getByIdEmployeeQuery = new() { Id = id };
            GetByIdEmployeeResponse response = await Mediator.Send(getByIdEmployeeQuery);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommand updateEmployeeCommand)
        {
            UpdatedEmployeeResponse response = await Mediator.Send(updateEmployeeCommand);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteEmployeeCommand deleteEmployeeCommand = new() { Id = id };
            DeletedEmployeeResponse response = await Mediator.Send(deleteEmployeeCommand);
            return Ok(response);
        }

    }
}
