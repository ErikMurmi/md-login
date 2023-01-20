using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos;
using Entidades.Usuarios;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using transport_api.Models.Usuarios.Rol;
using transport_api.Models.Usuarios.Usuarios;
using transport_api.Models.Usuarios;

namespace transport_api.Controllers
{
    //[Authorize(Roles = "Administrador,Usuarios")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DbContextProy _context;

        private readonly IConfiguration _config;

        public UsuariosController(DbContextProy context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        //GET: api/Usuarios/Listar
        //[Authorize(Roles = "Administrador,Usuarios")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<UsuariosViewModel>> Listar()
        {


            //var usuario = await _context.Usuarios.Include(c => c.RolUsuarios).ToListAsync();
            var usuario = await _context.Usuarios.Include(rolU => rolU.rol).ToListAsync();

            return usuario.Select(c => new UsuariosViewModel
            {
                idUsuarios = c.idUsuarios,
                idRolUsuarios_FK = c.idRolUsuarios_FK,
                //rol = c.RolUsuarios.Nombre,
                NombreUsuario = c.NombreUsuario,
                ApellidoUsuario = c.ApellidoUsuario,
                EmailUsuario = c.EmailUsuario,
                Empresa = c.Empresa,
                PasswordUsuario_hash = c.PasswordUsuario_hash,
                condicion = c.condicion,
                rol = new RolViewModel
                {
                    Nombre = c.rol.Nombre
                },

            });
        }

        // GET: api/UsuariosRols/Mostrar/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Usuario>> Mostrar([FromRoute] int id)
        {
            var usuariosRol = await _context.Usuarios.FindAsync(id);

            if (usuariosRol == null)
            {
                return NotFound();
            }

            return Ok(new UsuariosViewModel
            {
                idUsuarios = usuariosRol.idUsuarios,
                idRolUsuarios_FK = usuariosRol.idRolUsuarios_FK,
                NombreUsuario = usuariosRol.NombreUsuario,
                ApellidoUsuario = usuariosRol.ApellidoUsuario,
                EmailUsuario = usuariosRol.EmailUsuario,
                Empresa= usuariosRol.Empresa
            });
        }

        // PUT: api/UsuariosRols/5/Actualizar

        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.idUsuarios <= 0)
            {
                return BadRequest();
            }

            var usuarios = await _context.Usuarios.FirstOrDefaultAsync(c => c.idUsuarios == model.idUsuarios);

            if (usuarios == null)
            {
                return NotFound();
            }

            usuarios.idRolUsuarios_FK = model.idRolUsuarios_FK;
            usuarios.NombreUsuario = model.NombreUsuario;
            usuarios.ApellidoUsuario = model.ApellidoUsuario;
            usuarios.EmailUsuario = model.EmailUsuario.ToLower();
            usuarios.Empresa = model.Empresa;
            //usuarios.PasswordUsuario_hash = model.PasswordUsuario_hash;
            //usuarios.PasswordUsuario_salt = model.PasswordUsuario_hash;
            if (model.act_password == true)
            {
                CrearPasswordHash(model.PasswordUsuario, out byte[] passwordHash, out byte[] passwordSalt);
                usuarios.PasswordUsuario_hash = passwordHash;
                usuarios.PasswordUsuario_salt = passwordSalt;
            }
            // usuarios.PasswordUsuario_hash = model.PasswordUsuario_hash;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Guardar Excepcion
                return BadRequest();

            }

            return Ok();
        }

        // POST: api/UsuariosRols/Crear

        [HttpPost("[action]")]
        public async Task<ActionResult> Crear([FromBody] CrearViewModel model)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var email = model.EmailUsuario.ToLower();

            if (await _context.Usuarios.AnyAsync(c => c.EmailUsuario == email))
            {
                return BadRequest("El email ya existe");
            }
            CrearPasswordHash(model.PasswordUsuario, out byte[] passwordHash, out byte[] passwordSalt);
            Usuario usua = new Usuario
            {
                idRolUsuarios_FK = model.idRolUsuarios_FK,
                NombreUsuario = model.NombreUsuario,
                ApellidoUsuario = model.ApellidoUsuario,
                EmailUsuario = model.EmailUsuario.ToLower(),
                Empresa = model.Empresa,
                PasswordUsuario_hash = passwordHash,
                PasswordUsuario_salt = passwordSalt,
                condicion = true

            };
            _context.Usuarios.Add(usua);
            try
            {

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //envio la llave
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));//envio la contrasenia encriptada
            }

        }


        // DELETE: api/UsuariosRols/Eliminar/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<Usuario>> Eliminar([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuariosRol = await _context.Usuarios.FindAsync(id);
            if (usuariosRol == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuariosRol);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }



            return Ok(usuariosRol);
        }


        //PUT: api/UsuariosRols/Desactivar/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var usuarios = await _context.Usuarios.FirstOrDefaultAsync(c => c.idUsuarios == id);

            if (usuarios == null)
            {
                return NotFound();
            }
            usuarios.condicion = false;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Guardar Excepcion
                return BadRequest();

            }

            return Ok();
        }

        //PUT: api/UsuariosRols/Activar/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var usuarios = await _context.Usuarios.FirstOrDefaultAsync(c => c.idUsuarios == id);

            if (usuarios == null)
            {
                return NotFound();
            }
            usuarios.condicion = true;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Guardar Excepcion
                return BadRequest();

            }

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var email = model.EmailUsuario.ToLower();
            var usuario = await _context.Usuarios.Where(u => u.condicion == true).FirstOrDefaultAsync(u => u.EmailUsuario == email);
            if (usuario == null)
            {
                return NotFound();
            }
            if (!VerificarPaswordHash(model.PasswordUsuario, usuario.PasswordUsuario_hash, usuario.PasswordUsuario_salt))//verificar si el usuario existe
            {
                return NotFound();
            }

            var role = await this._context.Roles.FirstAsync(r => r.idRolUsuarios == usuario.idRolUsuarios_FK);

            var roles = new string[] { role.Nombre };



            var claims = new List<Claim>
            {
                //Claims contiene informacion acerca del usuario
                //Son lo que es el usuario y no lo que el usuario puede hacer
                //para ASP.NET
                new Claim (ClaimTypes.NameIdentifier, usuario.idUsuarios.ToString()),
                new Claim (ClaimTypes.Email,email),
                new Claim (ClaimTypes.Role,usuario.idRolUsuarios_FK.ToString()),

                
                //para VUE
                new Claim ("idUsuarios",usuario.idUsuarios.ToString()),
                new Claim ("NombreUsuario",usuario.NombreUsuario),
                new Claim ("idRol",usuario.idRolUsuarios_FK.ToString()),
                new Claim ("empresa",usuario.Empresa.ToString()),
                new Claim("role", role.Nombre),
                new Claim("empresa", role.Nombre),




            };
            return Ok(new { token = GenerarToken(claims), rol = role.Nombre, emp = usuario.Empresa}
            );
        }

        private bool VerificarPaswordHash(string password, byte[] passwordHashAlmacenado, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))// envio el password salt con el que se encriptado el password almacenado
            {
                var passwordHashNuevo = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));//Vuelvo a encriptar el password
                return new ReadOnlySpan<byte>(passwordHashAlmacenado).SequenceEqual(new ReadOnlySpan<byte>(passwordHashNuevo)); // comparo si el passwordalmacenado es igual al password nuevo
            }
        }

        private string GenerarToken(List<Claim> claims)
        {
            //JWT(JSON WEB TOKENS)
            //Es un estandar abierto para la creacion de tokens de acceso que 
            //permite la propagacion de identidad y privilegios
            //Para indicar al usuario que privilegios va a tener

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds,
                claims: claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private bool UsuariosRolExists(int id)
        {
            return _context.Usuarios.Any(e => e.idUsuarios == id);
        }
    }
}
