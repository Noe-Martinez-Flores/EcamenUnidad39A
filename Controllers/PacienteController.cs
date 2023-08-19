using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenUnidad3.Models;

namespace ExamenUnidad3.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class PacienteController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PacienteController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var listaPacientes = await _context.Pacientes.ToListAsync();
        if (listaPacientes == null) return NotFound();
        return Ok(listaPacientes);
    }

    [HttpGet("Show")]
    public async Task<IActionResult> Show(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);
        if (paciente == null) return NotFound();
        return Ok(paciente);
    }

    [HttpPost("Store")]
    public async Task<IActionResult> Store([FromBody] Paciente paciente)
    {
        if (paciente == null) return BadRequest();
        _context.Add(paciente);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Show), new { id = paciente.Id }, paciente);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] Paciente paciente)
    {
        if (paciente == null) return BadRequest();
        var entity = await _context.Pacientes.FindAsync(paciente.Id);

        if (entity == null) NotFound();
        entity.Nombre = paciente.Nombre;
        entity.Especie = paciente.Especie;
        entity.Raza = paciente.Raza;
        entity.Peso = paciente.Peso;
        entity.FechaNacimiento = paciente.FechaNacimiento;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);
        if (paciente == null) return NotFound();
        _context.Pacientes.Remove(paciente);
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

