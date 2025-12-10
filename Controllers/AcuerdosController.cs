using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendingNEA_Backend.Data;
using VendingNEA_Backend.Models;

namespace VendingNEA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcuerdosController : ControllerBase
    {
        private readonly VendingNEADbContext _context;

        public AcuerdosController(VendingNEADbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acuerdo>>> GetAcuerdos()
        {
            return await _context.Acuerdos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Acuerdo>> GetAcuerdo(int id)
        {
            var acuerdo = await _context.Acuerdos.FindAsync(id);
            if (acuerdo == null) return NotFound();
            return acuerdo;
        }

        [HttpPost]
        public async Task<ActionResult<Acuerdo>> PostAcuerdo(Acuerdo acuerdo)
        {
            _context.Acuerdos.Add(acuerdo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAcuerdo), new { id = acuerdo.IdAcuerdo }, acuerdo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcuerdo(int id, Acuerdo acuerdo)
        {
            if (id != acuerdo.IdAcuerdo) return BadRequest();
            _context.Entry(acuerdo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcuerdo(int id)
        {
            var acuerdo = await _context.Acuerdos.FindAsync(id);
            if (acuerdo == null) return NotFound();
            _context.Acuerdos.Remove(acuerdo);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Funcionalidad extra: Control de vigencia (próximos a finalizar)
        [HttpGet("proximosAFinalizar")]
        public async Task<ActionResult<IEnumerable<Acuerdo>>> GetProximosAFinalizar()
        {
            var fechaLimite = DateTime.Now.AddDays(30); // Próximos 30 días
            return await _context.Acuerdos.Where(a => a.FechaFin <= fechaLimite && a.FechaFin > DateTime.Now).ToListAsync();
        }
    }
}