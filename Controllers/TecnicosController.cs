using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendingNEA_Backend.Data;
using VendingNEA_Backend.Models;

namespace VendingNEA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicosController : ControllerBase
    {
        private readonly VendingNEADbContext _context;

        public TecnicosController(VendingNEADbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetTecnicos()
        {
            var tecnicos = await _context.Tecnicos
                .Include(t => t.Empleado)
                .Select(t => new
                {
                    t.Legajo,
                    Nombre = t.Empleado.Nombre,
                    Apellido = t.Empleado.Apellido,
                    t.Especialidad,
                    t.NivelCertificacion
                })
                .ToListAsync();

            return Ok(tecnicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetTecnico(int id)
        {
            var tecnico = await _context.Tecnicos
                .Include(t => t.Empleado)
                .Where(t => t.Legajo == id)
                .Select(t => new
                {
                    t.Legajo,
                    Nombre = t.Empleado.Nombre,
                    Apellido = t.Empleado.Apellido,
                    t.Especialidad,
                    t.NivelCertificacion
                })
                .FirstOrDefaultAsync();

            if (tecnico == null) return NotFound();
            return Ok(tecnico);
        }

        [HttpPost]
        public async Task<ActionResult<Tecnico>> PostTecnico(Tecnico tecnico)
        {
            _context.Tecnicos.Add(tecnico);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTecnico), new { id = tecnico.Legajo }, tecnico);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTecnico(int id, Tecnico tecnico)
        {
            if (id != tecnico.Legajo) return BadRequest();
            _context.Entry(tecnico).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTecnico(int id)
        {
            var tecnico = await _context.Tecnicos.FindAsync(id);
            if (tecnico == null) return NotFound();
            _context.Tecnicos.Remove(tecnico);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}