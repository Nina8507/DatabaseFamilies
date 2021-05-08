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
    public class FamilyController:ControllerBase
    {
        private readonly IRepository<Family> _famRepo;

        public FamilyController(IRepository<Family> famRepo)
        {
            _famRepo = famRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamiliesAsync()
        {
            try
            {
                IList<Family> families = await _famRepo.GetAllAsync();
                return Ok(families);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500, e.Message);
            }
            
        }
        [HttpPost]
        public async Task<ActionResult<Family>> AddFamilyAsync([FromBody] Family family)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var famToAdd = await _famRepo.AddAsync(family); 
                return Created($"/{famToAdd.Id}", famToAdd);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500, e.Message);
            }
        }
        
    }
}