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

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> ReadAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UserExists(string username)
        {
            return await _ctx.Users.FirstOrDefaultAsync(x => x.Name == username) != null;
        }
    }
}