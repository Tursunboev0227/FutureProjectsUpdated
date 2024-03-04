using FutureProjects.Application.Abstractions.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FutureProjects.API.Controllers.UserControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserDeleteController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserDeleteController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpDelete]
        public async Task<bool> DeleteUserById(int id)
        {
            var result = await _userService.DeleteById(id);

            return result;
        }
    }
}
