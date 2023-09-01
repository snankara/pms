using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Delete;
using Application.Features.Departments.Commands.Update;
using Application.Features.Titles.Commands.Create;
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDepartmentCommand updateDepartmentCommand)
        {
            UpdatedDepartmentResponse response = await Mediator.Send(updateDepartmentCommand);
            return Ok(response);
        }
    }
}
