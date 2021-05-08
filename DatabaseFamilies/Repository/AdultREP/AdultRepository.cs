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
        public async Task<IList<Adult>> GetAllAsync()
        {
            await using CloudContext _context = new CloudContext();
            IList<Adult> adultsToReturn =  await _context.AdultTable.Include(a=> a.JobTitle).ToListAsync();
            foreach (var a in adultsToReturn)
            {
                Console.WriteLine(a.FirstName);
            }
            return adultsToReturn; 
        }

        public async Task<Adult> GetByIdAsync(int adultId)
        {
            await using CloudContext _context = new CloudContext();
            Adult adultToFind = await _context.AdultTable.Include(a=> a.JobTitle).FirstOrDefaultAsync(a=>  a.Id == adultId);
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
            await using CloudContext _context = new CloudContext();
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
            await using CloudContext _context = new CloudContext();
            Adult adultToRemove = await _context.AdultTable.FirstOrDefaultAsync(a => a.Id == adultId);
            if (adultToRemove != null)
            {
                _context.AdultTable.Remove(adultToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Adult> UpdateAsync(Adult adult)
        {
            await using CloudContext _context = new CloudContext();
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