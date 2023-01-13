using Datos.Mapping.Usuarios;
using Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public  class DbContextProy: DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }//Exponer la coleccion de usuarios en ese objeto
        public DbSet<RolUsuarios> Roles { get; set; }//Exponer la coleccion de usuarios en ese objeto


        //CONSTRUCTOR 
        public DbContextProy(DbContextOptions<DbContextProy> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//nos permite mapear las entidades con la base de datos

        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new UsuariosMap());//Aplicar la configuracion de UsuariosMap
            modelBuilder.ApplyConfiguration(new RolMap());//Aplicar la configuracion de RolMap
           


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-1745L0OO; Database=Proyecto_MS; Integrated Security=true; MultipleActiveResultSets=true; Trusted_Connection=TrueEncrypt=false;TrustServerCertificate=true");
            }
        }



    }
}
