using Microsoft.EntityFrameworkCore;
using Todo_Web.API.Models.Domain;

namespace Todo_Web.API.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Todo> Todos { get; set; }
    }
}
