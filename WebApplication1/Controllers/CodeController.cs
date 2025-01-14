using CodeExecuter.Application.Code.Commands.AddCode;
using CodeExecuter.Application.Code.Commands.AddCode.Dtos;
using CodeExecuter.Application.Code.Commands.ExecuteCode;
using CodeExecuter.Application.Code.Commands.ExecuteCode.Dtos;
using CodeExecuter.Application.Code.Queries.GetAllCodes;
using CodeExecuter.Application.Code.Queries.GetAllCodes.Dtos;
using CodeExecuter.Application.Code.Queries.GetDetails;
using CodeExecuter.Application.Code.Queries.GetDetails.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/Code
        [HttpPost("AddCode")]
        public async Task<AddCodeOutput> AddCode([FromBody] AddCodeCommand code)
        {
            return await _mediator.Send(code);
        }
        [HttpPost("ExecuteCode")]
        public async Task<ExecuteCodeOutput> ExecuteCode([FromBody] ExecuteCodeCommand code)
        {
            return await _mediator.Send(code);
        }

        // GET: api/Code
        [HttpGet("GetDetails")]
        public async Task<GetDetailsOutput> GetDetails([FromQuery] GetDetailsQuery query)
        {
            return await _mediator.Send(query);
        }
        // GET: api/Code
        [HttpGet("GetAllCodes")]
        public async Task<GetAllCodesOutput> GetAllCodes([FromQuery] GetAllCodesQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
