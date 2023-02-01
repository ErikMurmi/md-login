using System.ComponentModel.DataAnnotations;

namespace api.Models
{
  public class Rol
  {
    [Key]
    public int idRol { get; set; }
    [Required]
    [MaxLength(20)]
    public string Nombre { get; set; }
  }

}
