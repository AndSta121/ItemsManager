using ItemsManager.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ItemsManager.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions)
           : base(contextOptions)
        {

        }

        public DbSet<ItemModel> Items { get; set; }
    }
}
