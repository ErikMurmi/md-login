using System.ComponentModel.DataAnnotations;

namespace api.Models
{
  public class Aplicacion
  {
    [Key]
    public int idAplicacion { get; set; }
    public int NumeroAplicacion{ get; set; }
    public int NumeroPoliza { get; set; }
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; }
    [MaxLength(50)]
    public string Asegurado { get; set; }
    [MaxLength(50)]
    public string Pagador { get; set; }
    [MaxLength(20)]
    public string Desde { get; set; }
    [MaxLength(20)]
    public string Hasta { get; set; }
    [MaxLength(50)]
    public string TipoTransporte { get; set; }
    [MaxLength(50)]
    public string Perteneciente { get; set; }
    [DataType(DataType.Date)]
    public DateTime FechaEmbarque { get; set; }
    [MaxLength(50)]
    public string Consignada { get; set; }
    [DataType(DataType.Date)]
    public DateTime FechaLlegada { get; set; }
    [MaxLength(50)]
    public string EmbarcadoPor { get; set; }
    [MaxLength(50)]
    public string NotaPedido { get; set; }
    [MaxLength(50)]
    public string OrdenCompra { get; set; }
    [MaxLength(50)]
    public string AfianzadorAduana { get; set; }
    [MaxLength(50)]
    public string Incoterms { get; set; }
    [MaxLength(50)]
    public string Items { get; set; }
    [MaxLength(50)]
    public string Marca { get; set; }
    [MaxLength(6)]
    public string NO { get; set; }
    public double PesoBruto { get; set; }
    public int Bultos { get; set; }
    public double MontoCompra { get; set; }
    public double GastosJustificados { get; set; }
    public double SumaAsegurada { get; set; }
    [MaxLength(50)]
    public string Tasa { get; set; }
    public double ValorPrima { get; set; }
    [MaxLength(50)]
    public string Cobertura { get; set; }
    public string Deducible { get; set; }
    [MaxLength(50)]
    public string ObjetoSeguro { get; set; }
    [MaxLength(70)]
    public string Descripcion { get; set; }
    [MaxLength(150)]
    public string Observaciones { get; set; }
    [MaxLength(10)]
    public string Estado { get; set; }
    public int idEmpresa { get; set; }
  }
}
