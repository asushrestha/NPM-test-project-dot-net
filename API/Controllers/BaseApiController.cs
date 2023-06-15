using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;
using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandlePaginatedResult<T>(Result<PagedList<T>> result){
            if(result==null){
                return NotFound();
            }
            if(result.IsSuccess && result.Data!=null){
                Response.AddPaginationHeader(result.Data.CurrentPage,result.Data.TotalCount,result.Data.PageSize);
                return Ok(result.Data);
            }
            return BadRequest(result.Error);
        }
}

}