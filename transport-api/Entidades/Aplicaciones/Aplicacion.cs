using Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Aplicaciones
{
    [Table("Aplicaciones")]
    public class Aplicacion
    {
            [Key]
            public int idAplicaciones { get; set; }
            [Required]
            public int idRolUsuarios_FK { get; set; }
            [Required]
            public int idPoliza_FK { get; set; }
            [Required]
            public DateTime FechaApli { get; set; }
            [AllowNull]
            public string AseguradoApli { get; set; }
            [AllowNull]
            public string PagadorApli { get; set; }
            [Required]
            public DateTime DesdeApli { get; set; }
            [Required]
            public DateTime HastaApli { get; set; }
            [AllowNull]
            public string TipoTransporApli { get; set; }
            [AllowNull]
            public string PertenecienteApli { get; set; }
            [AllowNull]
            public DateTime FechaEmbarqueApli { get; set; }
            [AllowNull]
            public string ConsiganadaApli { get; set; }
            [AllowNull]
            public DateTime FechaLlegadaApli { get; set; }
            [AllowNull]
            public string EmbarcadoPorApli { get; set; }
            [AllowNull]
            public string NotaPedidoApli { get; set; }
            [AllowNull]
            public string OrdenCompraApli { get; set; }
            [AllowNull]
            public string AfianzadorAduanaApli { get; set; }
            [AllowNull]
            public string IncotermsApli { get; set; }
            [AllowNull]
            public string ItemsApli { get; set; }
            [AllowNull]
            public string Marca { get; set; }
            [AllowNull]
            public string NOApli { get; set; }
            [AllowNull]
            public string PesoBrutoApli { get; set; }
            [AllowNull]
            public string BultosApli { get; set; }
            [AllowNull]
            public string MontoCompraApli { get; set; }
            [AllowNull]
            public string GastosJustificadosApli { get; set; }
            [AllowNull]
            public string SumaAseguradaApli { get; set; }
            [AllowNull]
            public string TasaApli { get; set; }
            [AllowNull]
            public string ValorPrimaApli { get; set; }
            [AllowNull]
            public string CoberturaApli { get; set; }
            [AllowNull]
            public string DeducibleApli { get; set; }
            [AllowNull]
            public string ObjetoSeguroApli { get; set; }
            [AllowNull]
            public string DescripcionApli { get; set; }
            [AllowNull]
            public string ObservacionesApli { get; set; }
            [AllowNull]
            public string Empresa { get; set; }
        public bool condicion { get; set; }

            //public RolUsuarios RolUsuarios { get; set; }
            //[ForeignKey("idRolUsuarios_FK")]
    }
}
