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
        private readonly CloudContext _context;

        public FamilyRepository(CloudContext context)
        {
            _context = context;
        }

        public async Task<IList<Family>> GetAllAsync()
        {
            return await _context.FamilyTable.ToListAsync();
        }

        public async Task<Family> GetByIdAsync(int familyId)
        {
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
            Family famToRemove = await _context.FamilyTable.FirstOrDefaultAsync(f => f.Id == familyId);
            if (famToRemove != null)
            {
                _context.FamilyTable.Remove(famToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Family> UpdateAsync(Family family)
        {
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
