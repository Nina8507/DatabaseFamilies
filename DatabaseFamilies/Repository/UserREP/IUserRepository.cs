using System.Threading.Tasks;
using DatabaseFamilies.Models;

namespace DatabaseFamilies.Repository.UserREP
{
    public interface IUserRepository
    {
        Task<User> ValidateUserAsync(string username, string password);
    }
}