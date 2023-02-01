using System.ComponentModel.DataAnnotations;

namespace api.Models
{
  public class UsuarioRequest
  {
    [Key]
    public int IdUsuario { get; set; }
    [Required]
    public int IdRol { get; set; }
    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; }
    [Required]
    [MaxLength(50)]
    public string Apellido{ get; set; }
    [Required]
    [MaxLength(70)]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public int IdEmpresa { get; set; }
  }


}
