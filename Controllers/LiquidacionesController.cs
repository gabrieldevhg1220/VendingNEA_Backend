using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendingNEA_Backend.Data;
using VendingNEA_Backend.Models;

namespace VendingNEA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiquidacionesController : ControllerBase
    {
        private readonly VendingNEADbContext _context;

        public LiquidacionesController(VendingNEADbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Liquidacion>>> GetLiquidaciones()
        {
            return await _context.Liquidaciones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Liquidacion>> GetLiquidacion(int id)
        {
            var liquidacion = await _context.Liquidaciones.FindAsync(id);
            if (liquidacion == null) return NotFound();
            return liquidacion;
        }

        [HttpPost]
        public async Task<ActionResult<Liquidacion>> PostLiquidacion(Liquidacion liquidacion)
        {
            _context.Liquidaciones.Add(liquidacion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLiquidacion), new { id = liquidacion.IdLiquidacion }, liquidacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLiquidacion(int id, Liquidacion liquidacion)
        {
            if (id != liquidacion.IdLiquidacion) return BadRequest();
            _context.Entry(liquidacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLiquidacion(int id)
        {
            var liquidacion = await _context.Liquidaciones.FindAsync(id);
            if (liquidacion == null) return NotFound();
            _context.Liquidaciones.Remove(liquidacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}