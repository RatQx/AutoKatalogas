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
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Dalys>>> GetParts()
        {
            try
            {
                var list = await _context.Parts.ToListAsync();
                Ok(list);
                return list;
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // GET: api/Dalys/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Dalys>> GetDalys(int id)
        {

            try
            {
                var dalys = await _context.Parts.FindAsync(id);
                if (dalys == null)
                {
                    return NoContent();
                }
                Ok(dalys);
                return dalys;
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // PUT: api/Dalys/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutDalys(int id, Dalys dalys)
        {
            if (id != dalys.Id)
            {
                NoContent();
            }
            var pav = await _context.Parts.FindAsync(id);
            if (pav == null)
            {
                NoContent();
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
            dalys.AutomobilioId = pav.AutomobilioId;
            dalys.Material = pav.Material;
            dalys.Name = pav.Name;
            dalys.Placement = pav.Placement;
            dalys.Id = pav.Id;
            var auto_check = await _context.Autos.FindAsync(dalys.AutomobilioId);
            if(auto_check!=null)
            {
                try
                {

                    await _context.SaveChangesAsync();
                    Ok(dalys);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DalysExists(id))
                    {
                        return NoContent();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }

            return Ok();
        }

        // POST: api/Dalys
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Dalys>> PostDalys(DalysCreateReq dalys)
        {
            if (dalys == null)
            {
                return NoContent();
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
                        Created(nameof(dalys), dalys);
                        return CreatedAtAction("GetDalys", new { id = dalys.Id }, dalys);
                    }
                    catch (Exception ex)
                    {
                        return NotFound();
                    }
                }
            }
            return Ok();
        }

        // DELETE: api/Dalys/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDalys(int id)
        {
            var dalys = await _context.Parts.FindAsync(id);
            if (dalys == null)
            {
                return NoContent();
            }
            try
            {
                _context.Parts.Remove(dalys);
                await _context.SaveChangesAsync();
                Ok(dalys);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }

        private bool DalysExists(int id)
        {
            return _context.Parts.Any(e => e.Id == id);
        }
        
    }
}
