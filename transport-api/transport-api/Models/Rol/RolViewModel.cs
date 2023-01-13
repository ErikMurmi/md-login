using Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace transport_api.Models.Usuarios.Rol
{
    public class RolViewModel
    {
        public int idRolUsuarios { get; set; }
        public string Nombre { get; set; }
        public string descripcion { get; set; }
        public bool condicion { get; set; }

        public virtual List<Usuario> Usuarios { get; set; }

    }
}
