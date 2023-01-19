using Entidades.Transporte;
using Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Mapping.Usuarios
{
    public class TransTecnicoAseguMap : IEntityTypeConfiguration<TransTecnicoAsegu>
    {
        public void Configure(EntityTypeBuilder<TransTecnicoAsegu> builder)
        {

            builder.ToTable("TransporteTecnicoAsegu")
                .HasKey(c => c.idTecnicoAsegu);

        }
    }
}