using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos;
using Entidades.Usuarios;
using Microsoft.AspNetCore.Authorization;
using transport_api.Models.Usuarios.Rol;

namespace transport_api.Controllers
{
    //[Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolUsuariosController : ControllerBase
    {


        private readonly DbContextProy _context;

        public RolUsuariosController(DbContextProy context)
        {
            _context = context;
        }


        // GET: api/Roles/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<RolViewModel>> Listar()
        {
            var rol = await _context.Roles.ToListAsync();
            return rol.Select(r => new RolViewModel
            {
                idRolUsuarios = r.idRolUsuarios,
                Nombre = r.Nombre,
                descripcion = r.descripcion,
                condicion = r.condicion

            });
        }

        // GET: api/Roles/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var rol = await _context.Roles.Where(r => r.condicion == true).ToListAsync();
            return rol.Select(r => new SelectViewModel
            {
                idRolUsuarios = r.idRolUsuarios,
                Nombre = r.Nombre,


            });
        }




        private bool RolesExists(int id)
        {
            return _context.Roles.Any(e => e.idRolUsuarios == id);
        }
    }
}
