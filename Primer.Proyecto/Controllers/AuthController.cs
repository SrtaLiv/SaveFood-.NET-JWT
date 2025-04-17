using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Primer.Proyecto.Bd;
using Primer.Proyecto.DTO;
using Primer.Proyecto.Models;
using Primer.Proyecto.Services;

namespace Primer.Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController( IUserService userService)
        {
            _userService = userService;
        }
        
        // POST: api/Auth
        [HttpPost("PostLogin")]
        public ActionResult<string> PostLogin(UserDTO userDto)
        {
            if (userDto.Username == null || userDto.Password == null)
            {
                return BadRequest();
            }
            
            string token = _userService.Login(userDto);
            return Ok(token);
        }
        
        // POST: api/Auth
        [HttpPost("PostRegister")]
        public ActionResult<string> PostRegister(User user)
        {
            _userService.save(user);
            return Ok(user);
        }

        [HttpPut]
        public ActionResult<string> Put(int id)
        {
            return Ok(_userService.findById(id));
        }
        
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok(_userService.findAll());
        }
        
    }
}