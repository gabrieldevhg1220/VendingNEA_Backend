using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendingNEA_Backend.Data;
using VendingNEA_Backend.Models;

namespace VendingNEA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleComprasController : ControllerBase
    {
        private readonly VendingNEADbContext _context;

        public DetalleComprasController(VendingNEADbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleCompra>>> GetDetalleCompras()
        {
            return await _context.DetalleCompras.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleCompra>> GetDetalleCompra(int id)
        {
            var detalleCompra = await _context.DetalleCompras.FindAsync(id);
            if (detalleCompra == null) return NotFound();
            return detalleCompra;
        }

        [HttpPost]
        public async Task<ActionResult<DetalleCompra>> PostDetalleCompra(DetalleCompra detalleCompra)
        {
            _context.DetalleCompras.Add(detalleCompra);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDetalleCompra), new { id = detalleCompra.IdDetalle }, detalleCompra);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleCompra(int id, DetalleCompra detalleCompra)
        {
            if (id != detalleCompra.IdDetalle) return BadRequest();
            _context.Entry(detalleCompra).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleCompra(int id)
        {
            var detalleCompra = await _context.DetalleCompras.FindAsync(id);
            if (detalleCompra == null) return NotFound();
            _context.DetalleCompras.Remove(detalleCompra);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}