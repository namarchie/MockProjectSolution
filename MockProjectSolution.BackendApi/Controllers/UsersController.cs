using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProjectSolution.Application.Catalog.Users;
using MockProjectSolution.Application.Users.Dtos;

namespace MockProjectSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController (IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.Authenticate(request);
            if (string.IsNullOrEmpty(resultToken)) return BadRequest("Tai khoan hoac mat khau chua dung");
            return Ok(resultToken);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.Register(request);
            if (!result) return BadRequest("Dang ky khong thanh cong");
            return Ok();
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging ([FromQuery] GetUserPagingRequest request)
        {
            var users = await _userService.GetUsersPaging(request);
            return Ok(users);
        }
    }
}
