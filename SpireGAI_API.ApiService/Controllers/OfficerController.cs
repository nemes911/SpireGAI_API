using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpireGAI_API.ApiService.Models;
using SpireGAI_API.ApiService.Repository.command;

namespace SpireGAI_API.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfficerController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<officer> Add([FromBody] officer officer) 
        {
            var result = await _mediator.Send(new AddCommand<officer>(officer));

            return result;
        }
    }
}
