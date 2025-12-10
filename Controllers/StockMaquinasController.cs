using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendingNEA_Backend.Data;
using VendingNEA_Backend.Models;

namespace VendingNEA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockMaquinasController : ControllerBase
    {
        private readonly VendingNEADbContext _context;

        public StockMaquinasController(VendingNEADbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockMaquina>>> GetStockMaquinas()
        {
            return await _context.StockMaquinas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockMaquina>> GetStockMaquina(int id)
        {
            var stockMaquina = await _context.StockMaquinas.FindAsync(id);
            if (stockMaquina == null) return NotFound();
            return stockMaquina;
        }

        [HttpPost]
        public async Task<ActionResult<StockMaquina>> PostStockMaquina(StockMaquina stockMaquina)
        {
            _context.StockMaquinas.Add(stockMaquina);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStockMaquina), new { id = stockMaquina.IdStock }, stockMaquina);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockMaquina(int id, StockMaquina stockMaquina)
        {
            if (id != stockMaquina.IdStock) return BadRequest();
            _context.Entry(stockMaquina).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockMaquina(int id)
        {
            var stockMaquina = await _context.StockMaquinas.FindAsync(id);
            if (stockMaquina == null) return NotFound();
            _context.StockMaquinas.Remove(stockMaquina);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}