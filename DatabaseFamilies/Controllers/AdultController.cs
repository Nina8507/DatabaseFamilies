using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseFamilies.Models;
using DatabaseFamilies.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseFamilies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController: ControllerBase
    {
        private readonly IRepository<Adult> _adultRepo;

        public AdultController(IRepository<Adult> adultRepo)
        {
            _adultRepo = adultRepo;
        }
        
        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdultAsync([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var adultToAdd = await _adultRepo.AddAsync(adult); 
                return Created($"/{adultToAdd.FirstName}", adultToAdd);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAllUsersAsync()
        {
            try
            {
                IList<Adult> _adultList = await _adultRepo.GetAllAsync();
                return Ok(_adultList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500, e.Message);
            }
        }
    }
}