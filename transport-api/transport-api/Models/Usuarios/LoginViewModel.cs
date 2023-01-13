using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace transport_api.Models.Usuarios.Usuarios
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailUsuario { get; set; }
        [Required]
        public string PasswordUsuario { get; set; }
    }
}
