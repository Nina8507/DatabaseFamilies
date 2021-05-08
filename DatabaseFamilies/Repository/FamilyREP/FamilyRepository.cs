using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseFamilies.Models;
using DatabaseFamilies.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFamilies.Repository.FamilyREP
{
    public class FamilyRepository : IRepository<Family>
    {
        
        public async Task<IList<Family>> GetAllAsync()
        {
            await using CloudContext _context = new CloudContext();
            IList<Family> familiesToReturn = await _context.FamilyTable.Include(a=> a.Adults).ThenInclude(j=> j.JobTitle).ToListAsync();
            return familiesToReturn;
        }

        public async Task<Family> GetByIdAsync(int familyId)
        {
            await using CloudContext _context = new CloudContext();
            Family famToFind = await _context.FamilyTable.FirstOrDefaultAsync(f => f.Id == familyId);
            if (famToFind != null)
            {
                return famToFind;
            }

            {
                throw new Exception($"Cannot find family with {familyId} id!");
            }
        }

        public async Task<Family> AddAsync(Family family)
        {
            try
            {
                await using CloudContext _context = new CloudContext();
                var newFamily = await _context.FamilyTable.AddAsync(family);
                await _context.SaveChangesAsync();
                return newFamily.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public async Task RemoveAsync(int familyId)
        {
            await using CloudContext _context = new CloudContext();
            Family famToRemove = await _context.FamilyTable.FirstOrDefaultAsync(f => f.Id == familyId);
            if (famToRemove != null)
            {
                _context.FamilyTable.Remove(famToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Family> UpdateAsync(Family family)
        {
            await using CloudContext _context = new CloudContext();
            try
            {
                Family famToUpdate = await _context.FamilyTable.FirstAsync(f => f.Id == family.Id);
                _context.Update(famToUpdate);
                await _context.SaveChangesAsync();
                return famToUpdate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception($"Family not found!");
            }
        }
    }
}
