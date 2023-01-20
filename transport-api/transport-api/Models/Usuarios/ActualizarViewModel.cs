using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace transport_api.Models.Usuarios
{
    public class ActualizarViewModel
    {
        [Required]
        public int idUsuarios { get; set; }
        [Required]
        public int idRolUsuarios_FK { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre no debe tener más de 30 caracteres y minimo debe tener 3 caracteres")]

        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }

        public string EmailUsuario { get; set; }
        public string Empresa { get; set; }

        public string PasswordUsuario { get; set; }
        public bool act_password { get; set; }
    }
}
