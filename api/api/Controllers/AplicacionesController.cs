using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Models.Data;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacionesController : ControllerBase
    {
        private readonly AcmeDbContext _context;

        public AplicacionesController(AcmeDbContext context)
        {
            _context = context;
        }

        // GET: api/Aplicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aplicacion>>> GetAplicaciones()
        {
          if (_context.Aplicaciones == null)
          {
              return NotFound();
          }
            return await _context.Aplicaciones.ToListAsync();
        }

        // GET: api/Aplicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aplicacion>> GetAplicacion(int id)
        {
          if (_context.Aplicaciones == null)
          {
              return NotFound();
          }
            var aplicacion = await _context.Aplicaciones.FindAsync(id);

            if (aplicacion == null)
            {
                return NotFound();
            }

            return aplicacion;
        }

        // PUT: api/Aplicaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAplicacion(int id, Aplicacion aplicacion)
        {
            if (id != aplicacion.idAplicacion)
            {
                return BadRequest();
            }

            _context.Entry(aplicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AplicacionExists(id))
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

        // POST: api/Aplicaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aplicacion>> PostAplicacion([FromBody]Aplicacion aplicacion)
        {
          if (_context.Aplicaciones == null)
          {
              return Problem("Entity set 'AcmeDbContext.Aplicaciones'  is null.");
          }
            _context.Aplicaciones.Add(aplicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAplicacion", new { id = aplicacion.idAplicacion }, aplicacion);
        }

        // DELETE: api/Aplicaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAplicacion(int id)
        {
            if (_context.Aplicaciones == null)
            {
                return NotFound();
            }
            var aplicacion = await _context.Aplicaciones.FindAsync(id);
            if (aplicacion == null)
            {
                return NotFound();
            }

            _context.Aplicaciones.Remove(aplicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AplicacionExists(int id)
        {
            return (_context.Aplicaciones?.Any(e => e.idAplicacion == id)).GetValueOrDefault();
        }
    }
}
