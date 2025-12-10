using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendingNEA_Backend.Data;
using VendingNEA_Backend.Models;

namespace VendingNEA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsablesController : ControllerBase
    {
        private readonly VendingNEADbContext _context;

        public ResponsablesController(VendingNEADbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Responsable>>> GetResponsables()
        {
            return await _context.Responsables.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Responsable>> GetResponsable(int id)
        {
            var responsable = await _context.Responsables.FindAsync(id);
            if (responsable == null) return NotFound();
            return responsable;
        }

        [HttpPost]
        public async Task<ActionResult<Responsable>> PostResponsable(Responsable responsable)
        {
            _context.Responsables.Add(responsable);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetResponsable), new { id = responsable.IdResponsable }, responsable);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponsable(int id, Responsable responsable)
        {
            if (id != responsable.IdResponsable) return BadRequest();
            _context.Entry(responsable).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponsable(int id)
        {
            var responsable = await _context.Responsables.FindAsync(id);
            if (responsable == null) return NotFound();
            _context.Responsables.Remove(responsable);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}