using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Usuarios
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int idUsuarios { get; set; }
        [Required]
        public int idRolUsuarios_FK { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tenier minimo 3 caracteres y maximo 100")]
        public string NombreUsuario { get; set; }
        [Required]
        public string ApellidoUsuario { get; set; }
        [Required]
        public string EmailUsuario { get; set; }
        [Required]
        public byte[] PasswordUsuario_hash { get; set; }
        [Required]
        public byte[] PasswordUsuario_salt { get; set; }
        public bool condicion { get; set; }

        //public RolUsuarios RolUsuarios { get; set; }
        [ForeignKey("idRolUsuarios_FK")]

        public virtual RolUsuarios rol { get; set; }

    }
}
