using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos;
using Entidades.Transporte;
using transport_api.Models.Transporte.Tecnico;
using transport_api.Models.Transporte.TecnicoAsegu;

namespace transport_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransTecnicoAsegusController : ControllerBase
    {
        private readonly DbContextProy _context;

        public TransTecnicoAsegusController(DbContextProy context)
        {
            _context = context;
        }

        //GET: api/TransTecnicoAsegus/Listar
        //[Authorize(Roles = "Administrador,Usuarios")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<TecnicoAseguViewModel>> Listar()
        {


            var tecnico = await _context.TransTecnicoAsegu.ToListAsync();

            return tecnico.Select(t => new TecnicoAseguViewModel
            {
                idTecnicoAsegu = t.idTecnicoAsegu,
                AseguradoAdiTecnicoAsegu = t.AseguradoAdiTecnicoAsegu,
                CodigoTecnicoAsegu = t.CodigoTecnicoAsegu,
                NombreTecnicoAsegu = t.NomPoliTecnicoAsegu,
                RucTecnicoAsegu = t.RucTecnicoAsegu,
                PagadorTecnicoAsegu = t.PagadorTecnicoAsegu,
                CodPolizaTecnicoAsegu = t.CodPolizaTecnicoAsegu,
                NomPoliTecnicoAsegu = t.NomPoliTecnicoAsegu,
                AseguPoliTecnicoAsegu = t.AseguPoliTecnicoAsegu,
                RelaPoliTecnicoAsegu = t.RelaPoliTecnicoAsegu



            });
        }

        // POST: api/TransTecnicoAsegus/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult> Crear([FromBody] CrearAseguViewModel t)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TransTecnicoAsegu tec = new TransTecnicoAsegu
            {
                AseguradoAdiTecnicoAsegu = t.AseguradoAdiTecnicoAsegu,
                CodigoTecnicoAsegu = t.CodigoTecnicoAsegu,
                NombreTecnicoAsegu = t.NomPoliTecnicoAsegu,
                RucTecnicoAsegu = t.RucTecnicoAsegu,
                PagadorTecnicoAsegu = t.PagadorTecnicoAsegu,
                CodPolizaTecnicoAsegu = t.CodPolizaTecnicoAsegu,
                NomPoliTecnicoAsegu = t.NomPoliTecnicoAsegu,
                AseguPoliTecnicoAsegu = t.AseguPoliTecnicoAsegu,
                RelaPoliTecnicoAsegu = t.RelaPoliTecnicoAsegu,
                condicion = true

            };
            _context.TransTecnicoAsegu.Add(tec);
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

        // GET: api/TransTecnicoAsegus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransTecnicoAsegu>> GetTransTecnicoAsegu(int id)
        {
            if (_context.TransTecnicoAsegu == null)
            {
                return NotFound();
            }
            var transTecnicoAsegu = await _context.TransTecnicoAsegu.FindAsync(id);

            if (transTecnicoAsegu == null)
            {
                return NotFound();
            }

            return transTecnicoAsegu;
        }

        // PUT: api/TransTecnicoAsegus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransTecnicoAsegu(int id, TransTecnicoAsegu transTecnicoAsegu)
        {
            if (id != transTecnicoAsegu.idTecnicoAsegu)
            {
                return BadRequest();
            }

            _context.Entry(transTecnicoAsegu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransTecnicoAseguExists(id))
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

        // POST: api/TransTecnicoAsegus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransTecnicoAsegu>> PostTransTecnicoAsegu(TransTecnicoAsegu transTecnicoAsegu)
        {
            if (_context.TransTecnicoAsegu == null)
            {
                return Problem("Entity set 'DbContextProy.TransTecnicoAsegu'  is null.");
            }
            _context.TransTecnicoAsegu.Add(transTecnicoAsegu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransTecnicoAsegu", new { id = transTecnicoAsegu.idTecnicoAsegu }, transTecnicoAsegu);
        }

        // DELETE: api/TransTecnicoAsegus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransTecnicoAsegu(int id)
        {
            if (_context.TransTecnicoAsegu == null)
            {
                return NotFound();
            }
            var transTecnicoAsegu = await _context.TransTecnicoAsegu.FindAsync(id);
            if (transTecnicoAsegu == null)
            {
                return NotFound();
            }

            _context.TransTecnicoAsegu.Remove(transTecnicoAsegu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransTecnicoAseguExists(int id)
        {
            return (_context.TransTecnicoAsegu?.Any(e => e.idTecnicoAsegu == id)).GetValueOrDefault();
        }
    }
}