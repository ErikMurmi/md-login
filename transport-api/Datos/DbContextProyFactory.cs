using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Usuarios;
using Entidades.Aplicaciones;
using Entidades.Transporte;

namespace Datos
{
    public class DbContextProyFactory : IDesignTimeDbContextFactory<DbContextProy>
    {

        public DbSet<Usuario> Usuarios { get; set; }//Exponer la coleccion de usuarios en ese objeto
        public DbSet<RolUsuarios> Roles { get; set; }//Exponer la coleccion de usuarios en ese objeto
        public DbSet<Aplicacion> Aplicaciones { get; set; }//Exponer la coleccion de usuarios en ese objeto
        public DbSet<TransTecnico> TransTecnicos { get; set; }//Exponer la coleccion de usuarios en ese objeto

        public DbSet<TransTecnicoAsegu> TransTecnicoAsegu { get; set; }//Exponer la coleccion de usuarios en ese objeto
        public DbSet<TransBeneficiario> TransBeneficiario { get; set; }//Exponer la coleccion de usuarios en ese objeto
        public DbContextProy CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContextProy>();
            optionsBuilder.UseSqlServer("Server=LAPTOP-1745L0OO\\MSSQLLocalDB;Database=Proyecto_MS;Trusted_Connection=True;MultipleActiveResultSets=trueEncrypt=false;TrustServerCertificate=true");

            return new DbContextProy(optionsBuilder.Options);
        }
    }
}
