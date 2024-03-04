using FutureProjects.Application.Abstractions.IServices;
using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;

namespace FutureProjects.API.Controllers.UserControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserUpdateController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserUpdateController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPatch("UserUpdate")]
        public async Task<ActionResult<string>> Update(int id, UserDTO model)
        {
            var result = await _userService.Update(id, model);

            return Ok(result);
        }

        [HttpPatch("UpdateEmail")]
        public async Task<ActionResult<string>> UpdateEmail(int id, string email)
        {
            var result = await _userService.UpdateEmail(id, email);

            return Ok(result);
        }

        [HttpPatch("UpdateLogin")]
        public async Task<ActionResult<string>> UpdateLogin(int id, string login)
        {
            var result = await _userService.UpdateLogin(id, login);

            return Ok(result);
        }

        [HttpPatch("UpdateName")]
        public async Task<ActionResult<string>> UpdateName(int id, string name)
        {
            var result = await _userService.UpdateName(id, name);

            return Ok(result);
        }

        [HttpPatch("UpdateRole")]
        public async Task<ActionResult<string>> UpdateRole(int id, string role)
        {
            var result = await _userService.UpdateRole(id, role);

            return Ok(result);
        }

        [HttpPatch("UpdatePassword")]
        public async Task<ActionResult<string>> UpdatePassword(int id, string password)
        {
            var result = await _userService.UpdatePassword(id, password);

            return Ok(result);
        }
    }
}
