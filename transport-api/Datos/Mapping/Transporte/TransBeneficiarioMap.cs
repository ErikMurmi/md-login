using Entidades.Transporte;
using Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Mapping.Usuarios
{
    public class TransBeneficioMap : IEntityTypeConfiguration<TransBeneficiario>
    {
        public void Configure(EntityTypeBuilder<TransBeneficiario> builder)
        {

            builder.ToTable("TransporteBeneficiario")
                .HasKey(c => c.idEndosoBene);

        }
    }
}