using Microsoft.EntityFrameworkCore;
using Recados.Models;

namespace Recados.Models;

public class RecadosContext : DbContext
{
    public RecadosContext(DbContextOptions<RecadosContext> options)
        : base(options)
    {
    }

    public DbSet<Recado> RecadoItem { get; set; } = null!;
}