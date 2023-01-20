using System.Diagnostics.CodeAnalysis;

namespace transport_api.Models.Aplicaciones
{
    public class AplicacionViewModel
    {
        public int idAplicaciones { get; set; }
        public int idRolUsuarios_FK { get; set; }
        public int idPoliza_FK { get; set; }
        public DateTime FechaApli { get; set; }
        public string AseguradoApli { get; set; }
        public string PagadorApli { get; set; }
        public DateTime DesdeApli { get; set; }
        public DateTime HastaApli { get; set; }
        public string TipoTransporApli { get; set; }
        public string PertenecienteApli { get; set; }
        public DateTime FechaEmbarqueApli { get; set; }
        public string ConsiganadaApli { get; set; }
        public DateTime FechaLlegadaApli { get; set; }
        public string EmbarcadoPorApli { get; set; }
        public string NotaPedidoApli { get; set; }
        public string OrdenCompraApli { get; set; }
        public string AfianzadorAduanaApli { get; set; }
        public string IncotermsApli { get; set; }
        public string ItemsApli { get; set; }
        public string Marca { get; set; }
        public string NOApli { get; set; }
        public string PesoBrutoApli { get; set; }
        public string BultosApli { get; set; }
        public string MontoCompraApli { get; set; }
        public string GastosJustificadosApli { get; set; }
        public string SumaAseguradaApli { get; set; }
        public string TasaApli { get; set; }
        public string ValorPrimaApli { get; set; }
        public string CoberturaApli { get; set; }
        public string DeducibleApli { get; set; }
        public string ObjetoSeguroApli { get; set; }
        public string DescripcionApli { get; set; }
        public string ObservacionesApli { get; set; }
        public bool condicion { get; set; }
    }
}
