using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using SpireGAI_API.ApiService.Repository.Handle;
using SpireGAI_API.ApiService.Repository.command;
using SpireGAI_API.ApiService.Models;
using SpireGAI_API.ApiService.Authoriz.Models;
using SpireGAI_API.ApiService.Authoriz.implemantation;
using SpireGAI_API.ApiService.Authoriz.Interface;


namespace SpireGAI_API.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IAuthorizationService _servicelogin;

        public UserController(IMediator mediator, IAuthorizationService servicelogin)
        {
            _mediator = mediator;
            _servicelogin = servicelogin;
        }
        [HttpPost]
        public async Task<ActionResult<OutLoginUserModel>> Logining([FromBody] LoginUserModel user_login) 
        {
            var result = await _servicelogin.AuthorizationAsync(user_login);

            if (result == null || string.IsNullOrEmpty(result.role))
                return Unauthorized("Неверный логин или пароль");

            return Ok(result);

        }


        [HttpPost]
        public async Task<LoginUserModel> Add_new_user([FromBody] LoginUserModel user) 
        {
            var result = await _mediator.Send(new AddCommand<LoginUserModel>(user));

            return result;
        }
        [HttpDelete]
        public async Task<LoginUserModel> Delete_user([FromBody] LoginUserModel user) 
        {
            var result = await _mediator.Send(new DeleteCommand<LoginUserModel>(user));

            return result;
        }
        
    }
}
