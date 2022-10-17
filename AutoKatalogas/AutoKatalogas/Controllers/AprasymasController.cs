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
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Aprasymas>>> GetDescriptions()
        {
            try
            {
                var list = await _context.Descriptions.ToListAsync();
                Ok(list);
                return list;
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // GET: api/Aprasymas/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Aprasymas>> GetAprasymas(int id)
        {
            try
            {
                var aprasymas = await _context.Descriptions.FindAsync(id);
                if (aprasymas == null)
                {
                    return NoContent();
                }
                Ok(aprasymas);
                return aprasymas;
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // PUT: api/Aprasymas/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAprasymas(int id, Aprasymas aprasymas)
        {
            if (id != aprasymas.Id)
            {
                return NoContent();
            }
            var pav = await _context.Descriptions.FindAsync(id);
            if (pav == null)
            {
                return NoContent();
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
                    Ok(aprasymas);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AprasymasExists(id))
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

        // POST: api/Aprasymas
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Aprasymas>> PostAprasymas(AprasymasCreateReq aprasymas)
        {

            if (aprasymas == null)
            {
                return NoContent();
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
                        Created(nameof(aprasymas), aprasymas);
                        return CreatedAtAction("GetAprasymas", new { id = aprasymas.Id }, aprasymas);
                    }
                    catch (Exception ex)
                    {
                        return NotFound();
                    }
                }
            }
            return Ok();
        }

        // DELETE: api/Aprasymas/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAprasymas(int id)
        {
            var aprasymas = await _context.Descriptions.FindAsync(id);
            if (aprasymas == null)
            {
                return NoContent();
            }
            try
            {
                _context.Descriptions.Remove(aprasymas);
                await _context.SaveChangesAsync();
                Ok(aprasymas);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return Ok();
        }

        private bool AprasymasExists(int id)
        {
            return _context.Descriptions.Any(e => e.Id == id);
        }
    }
}
