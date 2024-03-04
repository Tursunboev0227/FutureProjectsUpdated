using FutureProjects.Application.Abstractions.IServices;
using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;
using FutureProjects.Domain.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FutureProjects.API.Controllers.UserControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserCreateController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserCreateController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(UserDTO model)
        {
            var result = await _userService.Create(model);

            return Ok(result);
        }
    }
}
