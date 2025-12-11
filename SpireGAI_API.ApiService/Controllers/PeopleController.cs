using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpireGAI_API.ApiService.Models;
using SpireGAI_API.ApiService.Repository.command;

namespace SpireGAI_API.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PeopleController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<person> Add([FromBody] person person) 
        {
            var result = await _mediator.Send(new AddCommand<person>(person));

            return result;
        }
    }
}
