using FutureProjects.Application.Abstractions.IServices;
using FutureProjects.Domain.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FutureProjects.API.Controllers.UserControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserReadController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserReadController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers()
        {
            var result = await _userService.GetAll();

            return Ok(result);
        }

        [HttpPatch("GetByName")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetByName(string name)
        {
            var result = await _userService.GetByName(name);

            return Ok(result);
        }

        [HttpPatch("GetById")]
        public async Task<ActionResult<UserViewModel>> GetById(int id)
        {
            var result = await _userService.GetById(id);

            return Ok(result);
        }

        [HttpPatch("GetByRole")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetByRole(string role)
        {
            var result = await _userService.GetByRole(role);

            return Ok(result);
        }

        [HttpPatch("GetByLogin")]
        public async Task<ActionResult<UserViewModel>> GetByLogin(string login)
        {
            var result = await _userService.GetByLogin(login);

            return Ok(result);
        }

        [HttpPatch("GetByEmail")]
        public async Task<ActionResult<UserViewModel>> GetByEmail(string email)
        {
            var result = await _userService.GetByEmail(email);

            return Ok(result);
        }
    }
}
