using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendingNEA_Backend.Data;
using VendingNEA_Backend.Models;

namespace VendingNEA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoresController : ControllerBase
    {
        private readonly VendingNEADbContext _context;

        public RepositoresController(VendingNEADbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetRepositores()
        {
            var repositores = await _context.Repositores
                .Include(r => r.Empleado)
                .Select(r => new
                {
                    r.Legajo,
                    Nombre = r.Empleado.Nombre,
                    Apellido = r.Empleado.Apellido,
                    r.CategoriaLicencia,
                    r.Turno,
                    r.ZonaAsignada
                })
                .ToListAsync();

            return Ok(repositores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetRepositor(int id)
        {
            var repositor = await _context.Repositores
                .Include(r => r.Empleado)
                .Where(r => r.Legajo == id)
                .Select(r => new
                {
                    r.Legajo,
                    Nombre = r.Empleado.Nombre,
                    Apellido = r.Empleado.Apellido,
                    r.CategoriaLicencia,
                    r.Turno,
                    r.ZonaAsignada
                })
                .FirstOrDefaultAsync();

            if (repositor == null) return NotFound();
            return Ok(repositor);
        }

        [HttpPost]
        public async Task<ActionResult<Repositor>> PostRepositor(Repositor repositor)
        {
            _context.Repositores.Add(repositor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRepositor), new { id = repositor.Legajo }, repositor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepositor(int id, Repositor repositor)
        {
            if (id != repositor.Legajo) return BadRequest();
            _context.Entry(repositor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepositor(int id)
        {
            var repositor = await _context.Repositores.FindAsync(id);
            if (repositor == null) return NotFound();
            _context.Repositores.Remove(repositor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}