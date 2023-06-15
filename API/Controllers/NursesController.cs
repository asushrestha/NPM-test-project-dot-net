
using Microsoft.AspNetCore.Mvc;

using Domain;
using MediatR;
using Application.Nurses;
using Application.Core;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
        public async Task<ActionResult<Result<PagedList<Nurse>>>> GetNurses([FromQuery] PagingParams param)
        {
            // var user = HttpContext.User;

            // // Get the user's identifier
            // var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // // Get other claims
            // var email = user.FindFirst(ClaimTypes.Email)?.Value;
            //todo further mappping for create and update apis
            return HandlePaginatedResult(await _mediator.Send(new List.Query { Params = param }));
        }
        [HttpPost("add-nurse")]
        public async Task<IActionResult> AddNewNurse([FromBody] Nurse nurse)
        {
            try{
            await _mediator.Send(new Create.Command { Nurse = nurse });
            return Ok(new { Message = "Nurse is added successfully!" });
            }
            catch(Exception ex){
                return BadRequest(new { Error = "Failed to add nurse:" + ex.Message });
            }

        }
        [HttpPut("edit-nurse/{id}")]
        public async Task<IActionResult> EditNurseById(Guid id, Nurse nurse)
        {
            nurse.Id = id;
            try
            {
                await _mediator.Send(new Edit.Command { Nurse = nurse });
                return Ok(new { Message = "Nurse is updated successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Failed to edit nurse:" + ex.Message });
            }

        }

        [HttpDelete("delete-nurse/{id}")]
        public async Task<IActionResult> DeleteNurseById(Guid id)
        {
            try
            {
                await _mediator.Send(new Delete.Command { Id = id });
                return Ok(new { Message = "Nurse is successfully deleted!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Failed to delete nurse : " + ex.Message });

            }

        }
        [HttpGet("get-nurse-by-id/{id}")]
        public async Task<ActionResult<Result<Nurse>>> GetNurseById(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }
        [HttpPut("mark-rounding-manager/{id}")]
        public async Task<ActionResult<Nurse>> MarkNurseAsRoundingManger(Guid id)
        {
            try
            {
                await _mediator.Send(new MarkNurseAsRoundingOfficer.Command { Id = id });
                return Ok(new { Message = "Nurse is succssfully made a rounding manager" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Failed to mark nurse as rounding manager: " + ex.Message });
            }
        }
        [HttpPut("remove-rounding-manager/{id}")]
        public async Task<ActionResult<Nurse>> RemoveNurseFromRoundingManager(Guid id)
        {
            try
            {
                await _mediator.Send(new RemoveNurseFromRoundingManager.Command { Id = id });
                return Ok(new { Message = "Nurse successfully removed from rounding manager." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Failed to remove nurse from rounding manager: " + ex.Message });
            }
        }

    }
}