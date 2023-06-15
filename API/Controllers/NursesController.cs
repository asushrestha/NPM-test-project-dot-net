
using Microsoft.AspNetCore.Mvc;

using Domain;
using MediatR;
using Application.Nurses;

namespace API.Controllers
{

    public class NursesController : BaseApiController
    {
        private readonly IMediator _mediator;
        public NursesController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet("nurse")]
        public async Task<ActionResult<List<Nurse>>> GetNurses()
        {

            return await _mediator.Send(new List.Query());
        }
        [HttpPost("add-nurse")]
        public async Task<IActionResult> AddNewNurse([FromBody] Nurse nurse)
        {
            return Ok(await _mediator.Send(new Create.Command { Nurse = nurse }));
        }
        [HttpPut("edit-nurse/{id}")]
        public async Task<IActionResult> EditNurseById(Guid id, Nurse nurse)
        {
            nurse.Id = id;
            return Ok(await _mediator.Send(new Edit.Command { Nurse = nurse }));

        }

        [HttpDelete("delete-nurse/{id}")]
        public async Task<ActionResult<Nurse>> DeleteNurseById(Guid id)
        {
            return Ok(await _mediator.Send(new Delete.Command { Id = id }));

        }
        [HttpGet("get-nurse-by-id/{id}")]
        public async Task<ActionResult<Nurse>> GetNurseById(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }
        [HttpPut("mark-rounding-manager/{id}")]
        public async Task<ActionResult<Nurse>> MarkNurseAsRoundingManger(Guid id)
        {
            return Ok();
        }
        [HttpPut("remove-rounding-manager/{id}")]
        public async Task<ActionResult<Nurse>> RemoveNurseFromRoundingManager(Guid id)
        {
            return Ok();
        }

    }
}