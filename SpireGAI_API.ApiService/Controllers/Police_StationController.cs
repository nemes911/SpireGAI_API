using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpireGAI_API.ApiService.Models;
using SpireGAI_API.ApiService.Repository.command;

namespace SpireGAI_API.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Police_StationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public Police_StationController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<police_station> Add([FromBody] police_station police_Station) 
        {
            var result = await _mediator.Send(new AddCommand<police_station>(police_Station));

            return result;
        }
    }
}
