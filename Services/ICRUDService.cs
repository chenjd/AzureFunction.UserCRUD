using System;
using System.Threading.Tasks;
using UserCRUD.FuncApp.Model;

namespace UserCRUD.FuncApp.Services
{
    public interface ICRUDService
    {
        Task<User> CreateAsync(User user);
        Task<User> ReadAsync(Guid id);
        Task<User> UpdateAsync(Guid id, User user);
        Task<bool> DeleteAsync(Guid id);
    }
}