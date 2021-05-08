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
        public async Task<ActionResult<IList<Adult>>> GetAllAdultsAsync()
        {
            try
            {
                IList<Adult> adultList = await _adultRepo.GetAllAsync();
                Console.WriteLine(adultList.Count);
                return Ok(adultList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdateAdultAsync([FromBody] Adult adult)
        {
            try
            {
                Adult adultToUpdate = await _adultRepo.UpdateAsync(adult);
                return Ok(adultToUpdate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> GetAdultAsync([FromRoute] int id)
        {
            try
            {
                Adult adultAsync = await _adultRepo.GetByIdAsync(id);
                return Ok(adultAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task DeleteAdultAsync([FromRoute] int id)
        {
            try
            {
                await _adultRepo.RemoveAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}