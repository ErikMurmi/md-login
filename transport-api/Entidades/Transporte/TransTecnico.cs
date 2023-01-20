using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Entidades.Transporte
{
    [Table("TransporteTecnico")]

    public class TransTecnico
    {
        [Key]
        public int idTransporteTecnico { get; set; }
        [AllowNull]
        public string ComisioTransTecnico { get; set; }
        [AllowNull]

        public string TasaTransTecnico { get; set; }
        [AllowNull]

        public string NumeroPolizaRiesgosTransTecnico { get; set; }
        [AllowNull]

        public string DiazRetroactiviTransTecnico { get; set; }
        [AllowNull]

        public bool condicion { get; set; }




    }
}