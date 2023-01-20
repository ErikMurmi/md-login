using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Usuarios;

namespace Datos
{
    public class DbContextProyFactory : IDesignTimeDbContextFactory<DbContextProy>
    {

        public DbSet<Usuario> Usuarios { get; set; }//Exponer la coleccion de usuarios en ese objeto
        public DbSet<RolUsuarios> Roles { get; set; }//Exponer la coleccion de usuarios en ese objeto
        public DbContextProy CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContextProy>();
            optionsBuilder.UseSqlServer("Server=ERIKM\\SQLEXPRESS;Database=Proyecto_MS;Trusted_Connection=True;MultipleActiveResultSets=trueEncrypt=false;TrustServerCertificate=true");

            return new DbContextProy(optionsBuilder.Options);
        }
    }
}
