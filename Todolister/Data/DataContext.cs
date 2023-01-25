using Microsoft.EntityFrameworkCore;
using Todolister.Models;

namespace Todolister.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Todo> Todos { get; set; }

        internal Task<Todo?> FindAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
