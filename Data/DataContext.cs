using Microsoft.EntityFrameworkCore;
using UserCRUD.FuncApp.Model;

namespace UserCRUD.FuncApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}

        public DbSet<User> Users { get; set; }
    }
}