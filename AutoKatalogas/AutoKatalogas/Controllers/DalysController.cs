using AutoKatalogas.Data;
using AutoKatalogas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AutoKatalogas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DalysController : ControllerBase
    {
        private ApiContext _context;

        public DalysController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Dalys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dalys>>> GetParts()
        {
            try
            {
                return await _context.Parts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.ToString());
            }
        }

        // GET: api/Dalys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dalys>> GetDalys(int id)
        {

            try
            {
                var dalys = await _context.Parts.FindAsync(id);
                if (dalys == null)
                {
                    throw new ArgumentNullException(nameof(dalys));
                }
                return dalys;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.ToString());
            }
        }

        // PUT: api/Dalys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDalys(int id, Dalys dalys)
        {
            if (id != dalys.Id)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var pav = await _context.Parts.FindAsync(id);
            if (pav == null)
            {
                throw new ArgumentNullException(nameof(dalys));
            }
            if (!string.IsNullOrEmpty(dalys.Material))
            {
                pav.Material = dalys.Material;
            }
            if (!string.IsNullOrEmpty(dalys.Name))
            {
                pav.Name = dalys.Name;
            }
            if (!string.IsNullOrEmpty(dalys.Placement))
            {
                pav.Placement = dalys.Placement;
            }
            if (dalys.AutomobilioId!=null)
            {
                pav.AutomobilioId = dalys.AutomobilioId;
            }
            var auto_check = await _context.Autos.FindAsync(dalys.AutomobilioId);
            if(auto_check!=null)
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DalysExists(id))
                    {
                        throw new ArgumentNullException(nameof(id));
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return NoContent();
        }

        // POST: api/Dalys
        [HttpPost]
        public async Task<ActionResult<Dalys>> PostDalys(DalysCreateReq dalys)
        {
            if (dalys == null)
            {
                throw new ArgumentNullException(nameof(dalys));
            }
            if (dalys.Name != null && dalys.Material != null && dalys.AutomobilioId != null&& dalys.Placement != null)
            {
                var auto_check = await _context.Autos.FindAsync(dalys.AutomobilioId);
                if (auto_check != null)
                {
                    try
                    {
                        _context.Parts.Add(dalys.ToDalys());
                        await _context.SaveChangesAsync();

                        return CreatedAtAction("GetDalys", new { id = dalys.Id }, dalys);
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentNullException(ex.ToString());
                    }
                }
            }
            return NoContent();
        }

        // DELETE: api/Dalys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDalys(int id)
        {
            var dalys = await _context.Parts.FindAsync(id);
            if (dalys == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            try
            {
                _context.Parts.Remove(dalys);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.ToString());
            }
            return NoContent();
        }

        private bool DalysExists(int id)
        {
            return _context.Parts.Any(e => e.Id == id);
        }
        
    }
}
