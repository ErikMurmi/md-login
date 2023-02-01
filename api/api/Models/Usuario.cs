using System.ComponentModel.DataAnnotations;

namespace api.Models
{
  public class Usuario
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
    public string Apellido { get; set; }
    [Required]
    [MaxLength(70)]
    public string Email{ get; set; }
    [Required]
    public byte[] PasswordUsuarioHash { get; set; }
    [Required]
    public byte[] PasswordUsuarioSalt { get; set; }
    [Required]
    public int IdEmpresa { get; set; }
  }


}
