using System;
using System.Threading.Tasks;
using DatabaseFamilies.Models;
using DatabaseFamilies.Repository;
using DatabaseFamilies.Repository.UserREP;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseFamilies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IRepository<User> _userRepo;
        private readonly IUserRepository _validateUser;

        public UserController(IRepository<User> userRepo, IUserRepository validateUser)
        {
            _userRepo = userRepo;
            _validateUser = validateUser;
        }
        
        [HttpGet]
        public async Task<ActionResult<User>> ValidateUserAsync([FromQuery] string username,
            [FromQuery] string password)
        {
            try
            {
                var user = await _validateUser.ValidateUserAsync(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUserAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userToAdd = await _userRepo.AddAsync(user);
                Console.WriteLine("New user to add: " + user);
                Console.WriteLine(userToAdd);
                return Created($"/{userToAdd.UserName}", userToAdd);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500, e.Message);
            }
        }
    }
}