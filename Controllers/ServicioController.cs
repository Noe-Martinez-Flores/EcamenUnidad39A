using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenUnidad3.Models;
using System.Net;

namespace ExamenUnidad3.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ServicioController : ControllerBase
{

    private readonly ApplicationDbContext _context;
    public ServicioController(ApplicationDbContext context)
    {
        _context = context;
    }



    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var listServicios = await _context.Servicios.ToListAsync();
        if (listServicios == null || listServicios.Count == 0)
        {
            return NoContent();
        }
        return Ok(listServicios);
    }

    [HttpPost("Store")]
    public async Task<HttpStatusCode> Store([FromBody] Servicios servicios2)
    {
        if (servicios2 == null)
        {
            return HttpStatusCode.BadRequest;
        }
        _context.Add(servicios2);
        await _context.SaveChangesAsync();
        return HttpStatusCode.Created;
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] Servicios servicios2)
    {
        if (servicios2 == null)
        {
            return BadRequest(); //Error code 400
        }
        var entity = await _context.Servicios.FindAsync(servicios2.Id);
        if (entity == null)
        {
            return NotFound(); //Error code 404
        }
        entity.Nombre = servicios2.Nombre;
        entity.Descripcion = servicios2.Descripcion;
        entity.Costo = servicios2.Costo;
        entity.DuracionEstimada = servicios2.DuracionEstimada;
        entity.RequisitosPrevios = servicios2.RequisitosPrevios;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("Destroy")]
    public async Task<IActionResult> Destroy(int id)
    {
        var producto = await _context.Servicios.FindAsync(id);
        if (producto == null)
        {
            return NotFound();
        }
        _context.Servicios.Remove(producto);
        await _context.SaveChangesAsync();
        return Ok();
    }

}
