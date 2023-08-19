using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ExamenUnidad3.Models;
namespace ExamenUnidad3.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    

    public class CitasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CitasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listCitas = await _context.Cita.ToListAsync();
            if (listCitas == null || listCitas.Count == 0)
            {
                return NoContent();
            }
            return Ok(listCitas);
        }

        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            return Ok(cita);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Citas cita)
        {
            if (cita == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(cita);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Citas cita)
        {
            if (cita == null)
            {
                return BadRequest(); //Error code 400
            }
            var entity = await _context.Cita.FindAsync(cita.Id);
            if (entity == null)
            {
                return NotFound(); //Error code 404
            }
            entity.MotivoVisita = cita.MotivoVisita;
            entity.NombreVeterinario = cita.NombreVeterinario;
            entity.FechaReservada = cita.FechaReservada;
            entity.FechaAtencion = cita.FechaAtencion;
            entity.Observaciones = cita.Observaciones;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
