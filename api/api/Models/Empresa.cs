using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
  [Table("Empresas")]
  public class Empresa
  {
    [Key]
    [Column("idEmpresa")]
    public int idEmpresa { get; set; }

    [Column("Nombre")]
    public string Nombre { get; set; }
  }

}
