using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos;
using Entidades.Transporte;
using transport_api.Models.Usuarios.Rol;
using transport_api.Models.Usuarios;
using transport_api.Models.Transporte.Tecnico;

namespace transport_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransTecnicoController : ControllerBase
    {
        private readonly DbContextProy _context;

        public TransTecnicoController(DbContextProy context)
        {
            _context = context;
        }

        //GET: api/TransTecnico/Listar
        //[Authorize(Roles = "Administrador,Usuarios")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<TecnicoViewModel>> Listar()
        {


            var tecnico = await _context.TransTecnicos.ToListAsync();

            return tecnico.Select(t => new TecnicoViewModel
            {
                idTransporteTecnico = t.idTransporteTecnico,
                ComisioTransTecnico = t.ComisioTransTecnico,
                TasaTransTecnico = t.TasaTransTecnico,
                NumeroPolizaRiesgosTransTecnico = t.NumeroPolizaRiesgosTransTecnico,
                DiazRetroactiviTransTecnico = t.DiazRetroactiviTransTecnico


            });
        }
        // POST: api/TransTecnico/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult> Crear([FromBody] CrearTecViewModel t)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TransTecnico tec = new TransTecnico
            {
                ComisioTransTecnico = t.ComisioTransTecnico,
                TasaTransTecnico = t.TasaTransTecnico,
                NumeroPolizaRiesgosTransTecnico = t.NumeroPolizaRiesgosTransTecnico,
                DiazRetroactiviTransTecnico = t.DiazRetroactiviTransTecnico,
                condicion = true

            };
            _context.TransTecnicos.Add(tec);
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
        // GET: api/TransTecnico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransTecnico>> GetTransTecnico(int id)
        {
            if (_context.TransTecnicos == null)
            {
                return NotFound();
            }
            var transTecnico = await _context.TransTecnicos.FindAsync(id);

            if (transTecnico == null)
            {
                return NotFound();
            }

            return transTecnico;
        }

        // PUT: api/TransTecnico/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransTecnico(int id, TransTecnico transTecnico)
        {
            if (id != transTecnico.idTransporteTecnico)
            {
                return BadRequest();
            }

            _context.Entry(transTecnico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransTecnicoExists(id))
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

        // POST: api/TransTecnico
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransTecnico>> PostTransTecnico(TransTecnico transTecnico)
        {
            if (_context.TransTecnicos == null)
            {
                return Problem("Entity set 'DbContextProy.TransTecnicos'  is null.");
            }
            _context.TransTecnicos.Add(transTecnico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransTecnico", new { id = transTecnico.idTransporteTecnico }, transTecnico);
        }

        // DELETE: api/TransTecnico/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransTecnico(int id)
        {
            if (_context.TransTecnicos == null)
            {
                return NotFound();
            }
            var transTecnico = await _context.TransTecnicos.FindAsync(id);
            if (transTecnico == null)
            {
                return NotFound();
            }

            _context.TransTecnicos.Remove(transTecnico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransTecnicoExists(int id)
        {
            return (_context.TransTecnicos?.Any(e => e.idTransporteTecnico == id)).GetValueOrDefault();
        }
    }
}