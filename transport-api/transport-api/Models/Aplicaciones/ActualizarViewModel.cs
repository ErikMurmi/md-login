using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace transport_api.Models.Aplicaciones
{
    public class ActualizarViewModel
    {
        [Required]
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
        public string DescripcionApli { get; set; }
        [Required]
        public string Empresa { get; set; }
        [Required]
        public string ObservacionesApli { get; set; }
    }
}
