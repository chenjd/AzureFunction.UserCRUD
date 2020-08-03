using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserCRUD.FuncApp.Data;
using UserCRUD.FuncApp.Model;

namespace UserCRUD.FuncApp.Services
{
    public class CRUDService : ICRUDService
    {
        private readonly DataContext _ctx;
        public CRUDService(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<User> CreateAsync(User user)
        {
            if(await UserExists(user.Name))
                return null;
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await ReadAsync(id);
            if(user == null)
            {
                return false;
            }
            _ctx.Users.Remove(user);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<User> ReadAsync(Guid id)
        {
            var user = await _ctx.Users.FindAsync(id);
            return user;
        }

        public async Task<bool> UpdateAsync(Guid id, User user)
        {
            var userToBeUpdated = await ReadAsync(id);
            if(userToBeUpdated == null || user == null)
            {
                return false;
            }
            userToBeUpdated.Name = user.Name;
            userToBeUpdated.Password = user.Password;
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _ctx.Users.FirstOrDefaultAsync(x => x.Name == username) != null;
        }
    }
}