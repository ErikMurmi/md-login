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
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]


            public string AseguradoApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string PagadorApli { get; set; }
            [Required]
            
            public DateTime DesdeApli { get; set; }
            [Required]
            public DateTime HastaApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string TipoTransporApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string PertenecienteApli { get; set; }
            [Required]
            public DateTime FechaEmbarqueApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string ConsiganadaApli { get; set; }
            [Required]
            public DateTime FechaLlegadaApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string EmbarcadoPorApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string NotaPedidoApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string OrdenCompraApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string AfianzadorAduanaApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

             public string IncotermsApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string ItemsApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string Marca { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string NOApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string PesoBrutoApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string BultosApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string MontoCompraApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string GastosJustificadosApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string SumaAseguradaApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string TasaApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string ValorPrimaApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string CoberturaApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string DeducibleApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string ObjetoSeguroApli { get; set; }
            [Required]
            [StringLength(200, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 200")]
            public string DescripcionApli { get; set; }
            [Required]
            [StringLength(200, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 200")]

            public string ObservacionesApli { get; set; }
            [Required]
            [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe tenier minimo 1 caracteres y maximo 100")]

            public string Empresa { get; set; }
            public bool condicion { get; set; }

            //public RolUsuarios RolUsuarios { get; set; }
            //[ForeignKey("idRolUsuarios_FK")]
    }
}
