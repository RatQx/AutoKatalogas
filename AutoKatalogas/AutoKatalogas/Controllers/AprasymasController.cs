using AutoKatalogas.Data;
using AutoKatalogas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AutoKatalogas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AprasymasController : ControllerBase
    {
        private ApiContext _context;

        public AprasymasController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Aprasymas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aprasymas>>> GetDescriptions()
        {
            try
            {
                return await _context.Descriptions.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.ToString());
            }
        }

        // GET: api/Aprasymas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aprasymas>> GetAprasymas(int id)
        {
            try
            {
                var aprasymas = await _context.Descriptions.FindAsync(id);
                if (aprasymas == null)
                {
                    throw new ArgumentNullException(nameof(aprasymas));
                }
                return aprasymas;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.ToString());
            }
        }

        // PUT: api/Aprasymas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAprasymas(int id, Aprasymas aprasymas)
        {
            if (id != aprasymas.Id)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var pav = await _context.Descriptions.FindAsync(id);
            if (pav == null)
            {
                throw new ArgumentNullException(nameof(pav));
            }
            if (!string.IsNullOrEmpty(aprasymas.Name))
            {
                pav.Name = aprasymas.Name;
            }
            if (!string.IsNullOrEmpty(aprasymas.Name))
            {
                pav.Name = aprasymas.Name;
            }
            if (!string.IsNullOrEmpty(aprasymas.Type))
            {
                pav.Type = aprasymas.Type;
            }
            if (!string.IsNullOrEmpty(aprasymas.Description))
            {
                pav.Description = aprasymas.Description;
            }
            if (aprasymas.DalisId != null)
            {
                pav.DalisId = aprasymas.DalisId;
            }
            var part_check = await _context.Parts.FindAsync(aprasymas.DalisId);
            if (part_check != null || aprasymas.DalisId !=null) 
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AprasymasExists(id))
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

        // POST: api/Aprasymas
        [HttpPost]
        public async Task<ActionResult<Aprasymas>> PostAprasymas(AprasymasCreateReq aprasymas)
        {

            if (aprasymas == null)
            {
                throw new ArgumentNullException(nameof(aprasymas));
            }

            if(aprasymas.Name !=null && aprasymas.Type != null && aprasymas.Description != null && aprasymas.DalisId !=null)
            {
                var dalys_check = await _context.Parts.FindAsync(aprasymas.DalisId);
                if(dalys_check!=null)
                {
                    try
                    {
                        _context.Descriptions.Add(aprasymas.ToAprasymas());
                        await _context.SaveChangesAsync();

                        return CreatedAtAction("GetAprasymas", new { id = aprasymas.Id }, aprasymas);
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentNullException(ex.ToString());
                    }
                }
            }
            return NoContent();
        }

        // DELETE: api/Aprasymas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAprasymas(int id)
        {
            var aprasymas = await _context.Descriptions.FindAsync(id);
            if (aprasymas == null)
            {
                throw new ArgumentNullException(nameof(aprasymas));
            }
            try
            {
                _context.Descriptions.Remove(aprasymas);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.ToString());
            }

            return NoContent();
        }

        private bool AprasymasExists(int id)
        {
            return _context.Descriptions.Any(e => e.Id == id);
        }
    }
}
