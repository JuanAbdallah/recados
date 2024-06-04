using Microsoft.EntityFrameworkCore;
using RecadosBlazor.Models;

namespace RecadosBlazor.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options):base(options)
    {
        
    }
    public DbSet<Recado> Recados { get; set; } = null!;
}
