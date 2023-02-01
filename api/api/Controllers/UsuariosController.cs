using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Models.Data;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AcmeDbContext _context;
        private readonly IConfiguration _config;

        public UsuariosController(AcmeDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginRequest usuario)
    {

      var email = usuario.Email.ToLower();
      var usuario_log = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
      if (usuario_log == null)
      {
        return NotFound();
      }
      if (!VerificarPaswordHash(usuario.Password, usuario_log.PasswordUsuarioHash, usuario_log.PasswordUsuarioSalt))//verificar si el usuario existe
      {
        return NotFound();
      }

      var role = await this._context.Roles.FirstAsync(r => r.idRol == usuario_log.IdRol);
      var empr = await this._context.Empresas.FirstAsync(e => e.idEmpresa == usuario_log.IdEmpresa);

      string rol = role.Nombre;
      string empresa = empr.Nombre;



      var claims = new List<Claim>
            {
                new Claim("rol", rol),
                new Claim("empresa", empresa),

            };
      return Ok(new { token = GenerarToken(claims), rol = role.Nombre, empresa = empresa }
      );
    }

    // PUT: api/Usuarios/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(UsuarioRequest usuario)
        {
          if (_context.Usuarios == null)
          {
              return Problem("Entity set 'AcmeDbContext.Usuarios'  is null.");
          }

          var email = usuario.Email.ToLower();

          if (await _context.Usuarios.AnyAsync(c => c.Email == email))
          {
            return BadRequest("El email ya existe");
          }
          CrearPasswordHash(usuario.Password, out byte[] passwordHash, out byte[] passwordSalt);
          
          Usuario newUsuario = new Usuario {
            IdRol = usuario.IdRol ,
            Nombre = usuario.Nombre,
            Apellido = usuario.Apellido,
            Email = usuario.Email,
            PasswordUsuarioHash = passwordHash,
            PasswordUsuarioSalt = passwordSalt,
            IdEmpresa = usuario.IdEmpresa
          };

          _context.Usuarios.Add(newUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
          using (var hmac = new System.Security.Cryptography.HMACSHA512())
          {
            passwordSalt = hmac.Key; //envio la llave
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));//envio la contrasenia encriptada
          }

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
  }
}
