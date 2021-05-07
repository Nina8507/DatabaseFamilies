using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseFamilies.Models;
using DatabaseFamilies.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFamilies.Repository.AdultREP
{
    public class AdultRepository:IRepository<Adult>
    {
        private readonly CloudContext _context;

        public AdultRepository(CloudContext context)
        {
            _context = context;
        }
        public async Task<IList<Adult>> GetAllAsync()
        {
            return await _context.AdultTable.ToListAsync();
        }

        public async Task<Adult> GetByIdAsync(int adultId)
        {
            Adult adultToFind = await _context.AdultTable.FirstOrDefaultAsync(a=>  a.Id == adultId);
            if (adultToFind != null)
            {
                return adultToFind;
            }

            {
                throw new Exception($"Cannot find adult with {adultId} id!"); 
            }
        }

        public async Task<Adult> AddAsync(Adult adult)
        {
            try
            {
                var newAdult = await _context.AdultTable.AddAsync(adult);
                await _context.SaveChangesAsync();
                return newAdult.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public async Task RemoveAsync(int adultId)
        {
            Adult adultToRemove = await _context.AdultTable.FirstOrDefaultAsync(a => a.Id == adultId);
            if (adultToRemove != null)
            {
                _context.AdultTable.Remove(adultToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Adult> UpdateAsync(Adult adult)
        {
            try
            {
                Adult adultToUpdate = await _context.AdultTable.FirstAsync(a => a.Id == adult.Id);
                _context.Update(adultToUpdate);
                await _context.SaveChangesAsync();
                return adultToUpdate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception($"Adult not found!");
            }
        }
        
    }
}