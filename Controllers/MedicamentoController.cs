using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenUnidad3.Models;

namespace ExamenUnidad3.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class MedicamentoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MedicamentoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var listaMedicamentos = await _context.Medicamentos.ToListAsync();
        if (listaMedicamentos == null) return NotFound();
        return Ok(listaMedicamentos);
    }

    [HttpGet("Show")]
    public async Task<IActionResult> Show(int id)
    {
        var medicamento = await _context.Medicamentos.FindAsync(id);
        if (medicamento == null) return NotFound();
        return Ok(medicamento);
    }

    [HttpPost("Store")]
    public async Task<IActionResult> Store([FromBody] Medicamento medicamento)
    {
        if (medicamento == null) return BadRequest();
        _context.Add(medicamento);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Show), new { id = medicamento.Id }, medicamento);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] Medicamento medicamento)
    {
        if (medicamento == null) return BadRequest();
        var entity = await _context.Medicamentos.FindAsync(medicamento.Id);

        if (entity == null) NotFound();
        entity.Nombre = medicamento.Nombre;
        entity.Descripcion = medicamento.Descripcion;
        entity.DosisRecomendada = medicamento.DosisRecomendada;
        entity.FormaAdministracion = medicamento.FormaAdministracion;
        entity.Indicaciones = medicamento.Indicaciones;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var medicamento = await _context.Medicamentos.FindAsync(id);
        if (medicamento == null) return NotFound();
        _context.Medicamentos.Remove(medicamento);
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

