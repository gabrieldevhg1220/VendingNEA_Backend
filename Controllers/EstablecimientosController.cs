using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendingNEA_Backend.Data;
using VendingNEA_Backend.Models;

namespace VendingNEA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablecimientosController : ControllerBase
    {
        private readonly VendingNEADbContext _context;

        public EstablecimientosController(VendingNEADbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Establecimiento>>> GetEstablecimientos()
        {
            return await _context.Establecimientos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Establecimiento>> GetEstablecimiento(int id)
        {
            var establecimiento = await _context.Establecimientos.FindAsync(id);
            if (establecimiento == null) return NotFound();
            return establecimiento;
        }

        [HttpPost]
        public async Task<ActionResult<Establecimiento>> PostEstablecimiento(Establecimiento establecimiento)
        {
            _context.Establecimientos.Add(establecimiento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEstablecimiento), new { id = establecimiento.IdEstablecimiento }, establecimiento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstablecimiento(int id, Establecimiento establecimiento)
        {
            if (id != establecimiento.IdEstablecimiento) return BadRequest();
            _context.Entry(establecimiento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstablecimiento(int id)
        {
            var establecimiento = await _context.Establecimientos.FindAsync(id);
            if (establecimiento == null) return NotFound();
            _context.Establecimientos.Remove(establecimiento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}