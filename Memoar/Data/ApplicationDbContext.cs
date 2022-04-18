using Microsoft.EntityFrameworkCore;
using MemoarWeb.Models;

namespace MemoarWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        // DbSet <model name> table name
        public DbSet<Memoar> Memoars { get; set; }
    }
}
