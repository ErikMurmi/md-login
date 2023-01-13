using Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Mapping.Usuarios
{
    public class UsuariosMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ToTable("Usuarios")
                .HasKey(c => c.idUsuarios);//mapear la entidad Usuarios con la tabla Usuarios

        }
    }
}
