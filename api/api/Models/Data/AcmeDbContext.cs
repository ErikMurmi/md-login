using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Models.Data
{
  public class AcmeDbContext : DbContext
  {
    public AcmeDbContext(DbContextOptions<AcmeDbContext> context) : base(context)
    {

    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Aplicacion> Aplicaciones { get; set; }
    public DbSet<Empresa> Empresas { get; set; } = default!;

  }
}
