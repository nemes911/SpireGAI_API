using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpireGAI_API.ApiService.Models;
using SpireGAI_API.ApiService.Repository.command;

namespace SpireGAI_API.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncedentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IncedentsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<incident> Add([FromBody] incident incident) 
        {
            var result = await _mediator.Send(new AddCommand<incident>(incident));

            return result;
        }

        
    }
}
