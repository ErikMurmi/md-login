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
    [Table("TransporteTecnicoAsegu")]

    public class TransTecnicoAsegu
    {
        [Key]
        public int idTecnicoAsegu { get; set; }
        [AllowNull]
        public string AseguradoAdiTecnicoAsegu { get; set; }
        [AllowNull]

        public string CodigoTecnicoAsegu { get; set; }

        [AllowNull]

        public string NombreTecnicoAsegu { get; set; }


        [AllowNull]

        public string RucTecnicoAsegu { get; set; }
        [AllowNull]

        public string PagadorTecnicoAsegu { get; set; }
        [AllowNull]

        public string CodPolizaTecnicoAsegu { get; set; }

        [AllowNull]

        public string NomPoliTecnicoAsegu { get; set; }
        [AllowNull]

        public string AseguPoliTecnicoAsegu { get; set; }

        [AllowNull]

        public string RelaPoliTecnicoAsegu { get; set; }



        [AllowNull]

        public bool condicion { get; set; }

    }
}