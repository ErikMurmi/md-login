using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace transport_api.Models.Usuarios
{
    public class CrearViewModel
    {


        [Required]
        public int idRolUsuarios_FK { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre no debe tener más de 30 caracteres y minimo debe tener 3 caracteres")]
        public string NombreUsuario { get; set; }
        [Required]
        public string ApellidoUsuario { get; set; }
        [Required]
        [EmailAddress]
        public string EmailUsuario { get; set; }
        [Required]
        public string PasswordUsuario { get; set; }
    }
}
