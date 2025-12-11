using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpireGAI_API.ApiService.Models;
using SpireGAI_API.ApiService.Repository.command;

namespace SpireGAI_API.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<vehicle> Add([FromBody] vehicle vehicle) 
        {
            var result = await _mediator.Send(new AddCommand<vehicle>(vehicle));

            return result;
        }
    }
}
