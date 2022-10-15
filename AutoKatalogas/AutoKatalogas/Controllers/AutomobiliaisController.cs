using AutoKatalogas.Data;
using AutoKatalogas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AutoKatalogas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomobiliaisController : ControllerBase
    {
        private ApiContext _context;

        public AutomobiliaisController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Automobiliais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Automobiliai>>> GetAutos()
        {
            try
            {
                return await _context.Autos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.ToString());
            }
        }

        // GET: api/Automobiliais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Automobiliai>> GetAutomobiliai(int id)
        {
            try
            {
                var automobiliai = await _context.Autos.FindAsync(id);
                if(automobiliai==null)
                {
                    throw new ArgumentNullException(nameof(automobiliai));
                }
                return automobiliai;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.ToString());
            }
        }

        // PUT: api/Automobiliais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutomobiliai(int id, Automobiliai automobiliai)
        {
            if (id != automobiliai.id)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var pav = await _context.Autos.FindAsync(id);
            if (pav == null)
            {
                throw new ArgumentNullException(nameof(automobiliai));
            }
            if (!string.IsNullOrEmpty(automobiliai.Marke))
            {
                pav.Marke = automobiliai.Marke;
            }
            if (!string.IsNullOrEmpty(automobiliai.Model))
            {
                pav.Model = automobiliai.Model;
            }
            if (!string.IsNullOrEmpty(automobiliai.Vin))
            {
                pav.Vin = automobiliai.Vin;
            }
            if (automobiliai.Prodiction_date != null && automobiliai.Prodiction_date<= DateTime.Now)
            {
                pav.Prodiction_date = automobiliai.Prodiction_date;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutomobiliaiExists(id))
                {
                    throw new ArgumentNullException(nameof(id));
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Automobiliais
        [HttpPost]
        public async Task<ActionResult<Automobiliai>> PostAutomobiliai(Automobiliai automobiliai)
        {
            if (automobiliai == null)
            {
                throw new ArgumentNullException(nameof(automobiliai));
            }

            if (automobiliai.Prodiction_date != null 
                && automobiliai.Prodiction_date <= DateTime.Now
                && automobiliai.Marke!=null
                && automobiliai.Model!=null
                && automobiliai.Vin!=null)
            {
                _context.Autos.Add(automobiliai);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAutomobiliai", new { id = automobiliai.id }, automobiliai);
            }
            return NoContent();
            
        }

        // DELETE: api/Automobiliais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutomobiliai(int id)
        {
            var automobiliai = await _context.Autos.FindAsync(id);
            if (automobiliai == null)
            {
                throw new ArgumentNullException(nameof(automobiliai));
            }
            _context.Autos.Remove(automobiliai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutomobiliaiExists(int id)
        {
            return _context.Autos.Any(e => e.id == id);
        }
    }
}
