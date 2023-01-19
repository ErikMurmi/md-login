using Entidades.Transporte;
using Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Mapping.Usuarios
{
    public class TransTecnicoMap : IEntityTypeConfiguration<TransTecnico>
    {
        public void Configure(EntityTypeBuilder<TransTecnico> builder)
        {

            builder.ToTable("TransporteTecnico")
                .HasKey(c => c.idTransporteTecnico);

        }
    }
}