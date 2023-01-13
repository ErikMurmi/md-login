using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Usuarios
{
    public class RolUsuarios
    {
        public int idRolUsuarios { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "El nombre no debe tener más de 30 caracteres y minimo debe tener 5 caracteres")]
        public string Nombre { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }
        public bool condicion { get; set; }

        //public ICollection<Usuario> Usuarios { get;  set; }
        public virtual List<Usuario> Usuarios { get; set; }

    }
}
