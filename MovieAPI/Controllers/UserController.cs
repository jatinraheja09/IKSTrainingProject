using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Service;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("SelectUsers")]
        public IActionResult SelectUsers()
        {
            return Ok(_userService.selectUser());
        }

        [HttpPost("Register")]
        public IActionResult Register(UserModel userModel)
        {
            return Ok(_userService.Register(userModel));
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int userId)
        {
            return Ok(_userService.deleteUser(userId));
        }

        [HttpPost("Login")]
        public IActionResult Login(UserModel userModel)
        {
            return Ok(_userService.Login(userModel));
        }

        [HttpGet("findUserById")]
        public IActionResult findUserById(int id)
        {
            return Ok(_userService.findUserById(id));
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser(UserModel userModel)
        {
            return Ok(_userService.EditUser(userModel));
        }

    }
}
