using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos;
using Entidades.Aplicaciones;
using transport_api.Models.Aplicaciones;
using Entidades.Usuarios;

namespace transport_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacionesController : ControllerBase
    {
        private readonly DbContextProy _context;

        public AplicacionesController(DbContextProy context)
        {
            _context = context;
        }

        // GET: api/Aplicaciones
        [HttpGet("[action]")]
        public async Task<IEnumerable<AplicacionViewModel>> Listar()
        {
            var aplicacion = await _context.Aplicaciones.ToListAsync();

            return aplicacion.Select(c => new AplicacionViewModel
            {
                idAplicaciones = c.idAplicaciones,
                idRolUsuarios_FK = c.idRolUsuarios_FK,
                idPoliza_FK = c.idPoliza_FK,
                FechaApli = c.FechaApli,
                AseguradoApli = c.AseguradoApli,
                PagadorApli = c.PagadorApli,
                DesdeApli = c.DesdeApli,
                HastaApli = c.HastaApli,
                TipoTransporApli = c.TipoTransporApli,
                PertenecienteApli = c.PertenecienteApli,
                FechaEmbarqueApli = c.FechaEmbarqueApli,
                ConsiganadaApli = c.ConsiganadaApli,
                FechaLlegadaApli = c.FechaLlegadaApli,
                EmbarcadoPorApli = c.EmbarcadoPorApli, 
                NotaPedidoApli = c.NotaPedidoApli,
                OrdenCompraApli = c.OrdenCompraApli, 
                AfianzadorAduanaApli = c.AfianzadorAduanaApli,
                IncotermsApli = c.IncotermsApli,
                ItemsApli = c.ItemsApli,
                Marca = c.Marca,
                NOApli = c.NOApli,
                PesoBrutoApli = c.PesoBrutoApli,
                BultosApli = c.BultosApli,
                MontoCompraApli = c.MontoCompraApli,
                GastosJustificadosApli = c.GastosJustificadosApli,
                SumaAseguradaApli = c.SumaAseguradaApli,
                TasaApli = c.TasaApli,
                ValorPrimaApli = c.ValorPrimaApli,
                CoberturaApli = c.CoberturaApli,
                DeducibleApli = c.DeducibleApli,
                ObjetoSeguroApli = c.ObjetoSeguroApli, 
                DescripcionApli = c.DescripcionApli,
                ObservacionesApli = c.ObservacionesApli,
            });

          /*if (_context.Aplicaciones == null)
          {
              return NotFound();
          }
            return await _context.Aplicaciones.ToListAsync();*/
        }

        // GET: api/Aplicaciones/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Aplicacion>> Mostrar(int id)
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
            if (id != aplicacion.idAplicaciones)
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
        [HttpPost("[action]")]
        public async Task<ActionResult> Crear([FromBody] transport_api.Models.Aplicaciones.CreaAppViewModel c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Aplicacion aplic = new Aplicacion
            {
                idRolUsuarios_FK = c.idRolUsuarios_FK,
                idPoliza_FK = c.idPoliza_FK,
                FechaApli = c.FechaApli,
                AseguradoApli = c.AseguradoApli,
                PagadorApli = c.PagadorApli,
                DesdeApli = c.DesdeApli,
                HastaApli = c.HastaApli,
                TipoTransporApli = c.TipoTransporApli,
                PertenecienteApli = c.PertenecienteApli,
                FechaEmbarqueApli = c.FechaEmbarqueApli,
                ConsiganadaApli = c.ConsiganadaApli,
                FechaLlegadaApli = c.FechaLlegadaApli,
                EmbarcadoPorApli = c.EmbarcadoPorApli,
                NotaPedidoApli = c.NotaPedidoApli,
                OrdenCompraApli = c.OrdenCompraApli,
                AfianzadorAduanaApli = c.AfianzadorAduanaApli,
                IncotermsApli = c.IncotermsApli,
                ItemsApli = c.ItemsApli,
                Marca = c.Marca,
                NOApli = c.NOApli,
                PesoBrutoApli = c.PesoBrutoApli,
                BultosApli = c.BultosApli,
                MontoCompraApli = c.MontoCompraApli,
                GastosJustificadosApli = c.GastosJustificadosApli,
                SumaAseguradaApli = c.SumaAseguradaApli,
                TasaApli = c.TasaApli,
                ValorPrimaApli = c.ValorPrimaApli,
                CoberturaApli = c.CoberturaApli,
                DeducibleApli = c.DeducibleApli,
                ObjetoSeguroApli = c.ObjetoSeguroApli,
                DescripcionApli = c.DescripcionApli,
                ObservacionesApli = c.ObservacionesApli,
                condicion = true

            };
            _context.Aplicaciones.Add(aplic);
            try
            {

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();

            /*
            if (_context.Aplicaciones == null)
          {
              return Problem("Entity set 'DbContextProy.Aplicaciones'  is null.");
          }
            _context.Aplicaciones.Add(aplicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAplicacion", new { id = aplicacion.idAplicaciones }, aplicacion);*/
        }

        // DELETE: api/Aplicaciones/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar(int id)
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
            return (_context.Aplicaciones?.Any(e => e.idAplicaciones == id)).GetValueOrDefault();
        }
    }
}
