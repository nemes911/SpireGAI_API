using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpireGAI_API.ApiService.Models;
using SpireGAI_API.ApiService.Repository.command;

namespace SpireGAI_API.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Incident_vehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public Incident_vehicleController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<incident_vehicle> Add([FromBody] incident_vehicle incident_Vehicle) 
        {
            var result = await _mediator.Send(new AddCommand<incident_vehicle>(incident_Vehicle));

            return result;
        }
    }
}
