using Microsoft.EntityFrameworkCore;
using RecadoPages.Models;

namespace RecadoPages.Services
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Recado> Recados { get; set; }
    }
}
