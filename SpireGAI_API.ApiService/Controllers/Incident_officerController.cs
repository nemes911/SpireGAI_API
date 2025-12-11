using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpireGAI_API.ApiService.Models;
using SpireGAI_API.ApiService.Repository.command;

namespace SpireGAI_API.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Incident_officerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public Incident_officerController(IMediator mediator)=> _mediator = mediator;

        [HttpPost]
        public async Task<incident_officer> Add([FromBody] incident_officer incident_Officer) 
        {
            var result = await _mediator.Send(new AddCommand<incident_officer>(incident_Officer));

            return result;
        }
    }
}
