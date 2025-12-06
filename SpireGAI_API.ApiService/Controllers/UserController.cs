using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using SpireGAI_API.ApiService.Repository.Handle;
using SpireGAI_API.ApiService.Repository.command;
using SpireGAI_API.ApiService.Models;


namespace SpireGAI_API.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<user> Add_new_user([FromBody] user user) 
        {
            var result = await _mediator.Send(new AddCommand<user>(user));

            return result;
        }
        [HttpDelete]
        public async Task<user> Delete_user([FromBody] user user) 
        {
            var result = await _mediator.Send(new DeleteCommand<user>(user));

            return result;
        }
        
    }
}
