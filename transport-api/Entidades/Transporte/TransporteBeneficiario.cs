using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Transporte
{
    [Table("TransporteBeneficiario")]

    public class TransBeneficiario
    {
        [Key]
        public int idEndosoBene { get; set; }
        [AllowNull]
        public string NumeroPoliza { get; set; }
        [AllowNull]

        public string NumeroApliBene { get; set; }

        [AllowNull]

        public DateTime FechaEndoso { get; set; }


        [AllowNull]

        public string AseguradaBene { get; set; }
        [AllowNull]

        public string AseguradoBene { get; set; }
        [AllowNull]

        public string Beneficiario { get; set; }

        [AllowNull]

        public string ContenidoBene { get; set; }


        [AllowNull]

        public bool condicion { get; set; }

    }
}