using Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Mapping.Usuarios
{
    public class RolMap : IEntityTypeConfiguration<RolUsuarios>
    {
        public void Configure(EntityTypeBuilder<RolUsuarios> builder)
        {
            builder.ToTable("RolUsuarios")
             .HasKey(c => c.idRolUsuarios);
        }
    }
}
