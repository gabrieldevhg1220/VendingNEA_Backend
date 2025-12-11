using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendingNEA_Backend.Data;
using VendingNEA_Backend.Models;

namespace VendingNEA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinasController : ControllerBase
    {
        private readonly VendingNEADbContext _context;

        public MaquinasController(VendingNEADbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maquina>>> GetMaquinas()
        {
            return await _context.Maquinas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Maquina>> GetMaquina(int id)
        {
            var maquina = await _context.Maquinas.FindAsync(id);
            if (maquina == null) return NotFound();
            return maquina;
        }

        [HttpPost]
        public async Task<ActionResult<Maquina>> PostMaquina(Maquina maquina)
        {
            _context.Maquinas.Add(maquina);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMaquina), new { id = maquina.IdMaquina }, maquina);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaquina(int id, Maquina maquina)
        {
            if (id != maquina.IdMaquina) return BadRequest();
            _context.Entry(maquina).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaquina(int id)
        {
            var maquina = await _context.Maquinas.FindAsync(id);
            if (maquina == null) return NotFound();

            try
            {
                _context.Maquinas.Remove(maquina);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("REFERENCE constraint") == true)
            {
                return Conflict(new
                {
                    message = "No se puede eliminar la máquina porque tiene visitas, stock u otros datos relacionados.",
                    detalle = "Elimina primero los registros dependientes o marca la máquina como inactiva."
                });
            }
        }
    }
}