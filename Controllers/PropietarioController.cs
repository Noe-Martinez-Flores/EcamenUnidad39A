using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenUnidad3.Models;

namespace ExamenUnidad3.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class PropietarioController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PropietarioController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var listaPropietarios = await _context.Propietarios.ToListAsync();
        if (listaPropietarios == null) return NotFound();
        return Ok(listaPropietarios);
    }

    [HttpGet("Show")]
    public async Task<IActionResult> Show(int id)
    {
        var propietario = await _context.Propietarios.FindAsync(id);
        if (propietario == null) return NotFound();
        return Ok(propietario);
    }

    [HttpPost("Store")]
    public async Task<IActionResult> Store([FromBody] Propietario propietario)
    {
        if (propietario == null) return BadRequest();
        _context.Add(propietario);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Show), new { id = propietario.Id }, propietario);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] Propietario propietario)
    {
        if (propietario == null) return BadRequest();
        var entity = await _context.Propietarios.FindAsync(propietario.Id);

        if (entity == null) NotFound();
        entity.Nombre = propietario.Nombre;
        entity.Apellidos = propietario.Apellidos;
        entity.Direccion = propietario.Direccion;
        entity.Correo = propietario.Correo;
        entity.Telefono = propietario.Telefono;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var propietario = await _context.Propietarios.FindAsync(id);
        if (propietario == null) return NotFound();
        _context.Propietarios.Remove(propietario);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors(builder =>
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod());

        // Resto de la configuración del middleware...
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

