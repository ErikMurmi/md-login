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
            [Required]

            public string AseguradoApli { get; set; }
            [Required]
            public string PagadorApli { get; set; }
            [Required]
            
            public DateTime DesdeApli { get; set; }
            [Required]
            public DateTime HastaApli { get; set; }
            [Required]
            public string TipoTransporApli { get; set; }
            [Required]
            public string PertenecienteApli { get; set; }
            [Required]
            public DateTime FechaEmbarqueApli { get; set; }
            [Required]
            public string ConsiganadaApli { get; set; }
            [Required]
            public DateTime FechaLlegadaApli { get; set; }
            [Required]
            public string EmbarcadoPorApli { get; set; }
            [Required]
            public string NotaPedidoApli { get; set; }
            [Required]
            public string OrdenCompraApli { get; set; }
            [Required]
            public string AfianzadorAduanaApli { get; set; }
            [Required]
            public string IncotermsApli { get; set; }
            [Required]
            public string ItemsApli { get; set; }
            [Required]
            public string Marca { get; set; }
            [Required]
            public string NOApli { get; set; }
            [Required]
            public string PesoBrutoApli { get; set; }
            [Required]
            public string BultosApli { get; set; }
            [Required]
            public string MontoCompraApli { get; set; }
            [Required]
            public string GastosJustificadosApli { get; set; }
            [Required]
            public string SumaAseguradaApli { get; set; }
            [Required]
            public string TasaApli { get; set; }
            [Required]
            public string ValorPrimaApli { get; set; }
            [Required]
            public string CoberturaApli { get; set; }
            [Required]
            public string DeducibleApli { get; set; }
            [Required]
            public string ObjetoSeguroApli { get; set; }
            [Required]
            [StringLength(200, MinimumLength = 3, ErrorMessage = "Debe tenier minimo 3 caracteres y maximo 200")]
            public string DescripcionApli { get; set; }
            [Required]
            [StringLength(200, MinimumLength = 3, ErrorMessage = "Debe tenier minimo 3 caracteres y maximo 200")]

            public string ObservacionesApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 3, ErrorMessage = "Debe tenier minimo 3 caracteres y maximo 100")]

            public string Empresa { get; set; }
            public bool condicion { get; set; }

            //public RolUsuarios RolUsuarios { get; set; }
            //[ForeignKey("idRolUsuarios_FK")]
    }
}
