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
using transport_api.Models.Transporte.Beneficiario;

namespace transport_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransBeneficiariosController : ControllerBase
    {
        private readonly DbContextProy _context;

        public TransBeneficiariosController(DbContextProy context)
        {
            _context = context;
        }

        //GET: api/TransBeneficiarios/Listar
        //[Authorize(Roles = "Administrador,Usuarios")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<BeneficiarioViewModel>> Listar()
        {


            var tecnico = await _context.TransBeneficiario.ToListAsync();

            return tecnico.Select(t => new BeneficiarioViewModel
            {
                idEndosoBene = t.idEndosoBene,
                NumeroPoliza = t.NumeroPoliza,
                NumeroApliBene = t.NumeroApliBene,
                FechaEndoso = t.FechaEndoso,
                AseguradaBene = t.AseguradaBene,
                AseguradoBene = t.AseguradoBene,
                Beneficiario = t.Beneficiario,
                ContenidoBene = t.ContenidoBene,



            });
        }


        // POST: api/TransBeneficiarios/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult> Crear([FromBody] CrearBeneViewModel t)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TransBeneficiario tec = new TransBeneficiario
            {
                NumeroPoliza = t.NumeroPoliza,
                NumeroApliBene = t.NumeroApliBene,
                FechaEndoso = t.FechaEndoso,
                AseguradaBene = t.AseguradaBene,
                AseguradoBene = t.AseguradoBene,
                Beneficiario = t.Beneficiario,
                ContenidoBene = t.ContenidoBene,
                condicion = true

            };
            _context.TransBeneficiario.Add(tec);
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
        // GET: api/TransBeneficiarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransBeneficiario>> GetTransBeneficiario(int id)
        {
            if (_context.TransBeneficiario == null)
            {
                return NotFound();
            }
            var transBeneficiario = await _context.TransBeneficiario.FindAsync(id);

            if (transBeneficiario == null)
            {
                return NotFound();
            }

            return transBeneficiario;
        }

        // PUT: api/TransBeneficiarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransBeneficiario(int id, TransBeneficiario transBeneficiario)
        {
            if (id != transBeneficiario.idEndosoBene)
            {
                return BadRequest();
            }

            _context.Entry(transBeneficiario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransBeneficiarioExists(id))
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

        // POST: api/TransBeneficiarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransBeneficiario>> PostTransBeneficiario(TransBeneficiario transBeneficiario)
        {
            if (_context.TransBeneficiario == null)
            {
                return Problem("Entity set 'DbContextProy.TransBeneficiario'  is null.");
            }
            _context.TransBeneficiario.Add(transBeneficiario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransBeneficiario", new { id = transBeneficiario.idEndosoBene }, transBeneficiario);
        }

        // DELETE: api/TransBeneficiarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransBeneficiario(int id)
        {
            if (_context.TransBeneficiario == null)
            {
                return NotFound();
            }
            var transBeneficiario = await _context.TransBeneficiario.FindAsync(id);
            if (transBeneficiario == null)
            {
                return NotFound();
            }

            _context.TransBeneficiario.Remove(transBeneficiario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransBeneficiarioExists(int id)
        {
            return (_context.TransBeneficiario?.Any(e => e.idEndosoBene == id)).GetValueOrDefault();
        }
    }
}