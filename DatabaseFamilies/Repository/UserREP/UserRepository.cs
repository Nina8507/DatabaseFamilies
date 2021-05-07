using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseFamilies.Models;
using DatabaseFamilies.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFamilies.Repository.UserREP
{
    public class UserRepository:IRepository<User>, IUserRepository
    {
        private readonly CloudContext _context;

        public UserRepository(CloudContext context)
        {
            _context = context;
        } 
        public async Task<IList<User>> GetAllAsync()
        {
            return await _context.UserTable.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            User userToFind = await _context.UserTable.FirstOrDefaultAsync(u => u.UserId == userId);
            if (userToFind != null)
            {
                return userToFind;
            }

            {
                throw new Exception($"Cannot find user with {userId} id!"); 
            }
        }

        public async Task<User> AddAsync(User user)
        {
            try
            {
                var newAddedUser = await _context.UserTable.AddAsync(user);
                await _context.SaveChangesAsync();
                return newAddedUser.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
        
        public async Task RemoveAsync(int userId)
        {
            User userToRemove = await _context.UserTable.FirstOrDefaultAsync(u => u.UserId == userId);
            if (userToRemove != null)
            {
                _context.UserTable.Remove(userToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> UpdateAsync(User user)
        {
            try
            {
                User userToUpdate = await _context.UserTable.FirstAsync(u => u.UserId == user.UserId);
                _context.Update(userToUpdate);
                await _context.SaveChangesAsync();
                return userToUpdate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception($"User not found!");
            }
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            User validateUser = await _context.UserTable.FirstOrDefaultAsync(u =>
                u.UserName.Equals(username) && u.Password.Equals(password));
            if (validateUser != null)
            {
                return validateUser;
            }

            throw new Exception($"User not found!"); 
        }
    }
}