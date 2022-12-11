using AutoKatalogas.Auth.Model;
using AutoKatalogas.Data;
using AutoKatalogas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AutoKatalogas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchemaController : ControllerBase
    {
        private ApiContext _context;

        public SchemaController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Schema
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Schema>>> GetScheme()
        {
            try
            {
                var list = await _context.Scheme.ToListAsync();
                Ok(list);
                return list;
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // GET: api/Schema/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Schema>> GetSchema(int id)
        {
            try
            {
                var schema = await _context.Scheme.FindAsync(id);
                if (schema == null)
                {
                    return NoContent();
                }
                Ok(schema);
                return schema;
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // PUT: api/Schema/5
        [HttpPut("{id}")]
        [Authorize(Roles = ForumRoles.ForumUser)]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutSchema(int id, Schema schema)
        {
            if (id != schema.Id)
            {
                return NoContent();
            }
            var pav = await _context.Scheme.FindAsync(id);
            if (pav == null)
            {
                return NoContent();
            }
            if (!string.IsNullOrEmpty(schema.Img))
            {
                pav.Img = schema.Img;
            }
            if (schema.AprasymasId != null)
            {
                pav.AprasymasId = schema.AprasymasId;
            }
            var desc_check = await _context.Descriptions.FindAsync(schema.AprasymasId);
            if(desc_check!=null)
            {
                try
                {
                    await _context.SaveChangesAsync();
                    Ok(schema);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchemaExists(id))
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

        // POST: api/Schema
        [HttpPost]
        [Authorize(Roles = ForumRoles.ForumUser)]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Schema>> PostSchema(SchemaCreateReq schema)
        {
            if (schema == null)
            {
                return NoContent();
            }
            if(schema.Img !=null && schema.AprasymasId !=null)
            {
                var desc_check = await _context.Descriptions.FindAsync(schema.AprasymasId);
                if (desc_check != null)
                {
                    try
                    {
                        _context.Scheme.Add(schema.ToSchema());
                        await _context.SaveChangesAsync();
                        Created(nameof(schema), schema);
                        return CreatedAtAction("GetSchema", new { id = schema.Id }, schema);
                    }
                    catch (Exception ex)
                    {
                        return NotFound();
                    }
                }
            }
            return Ok();
        }

        // DELETE: api/Schema/5
        [HttpDelete("{id}")]
        [Authorize(Roles = ForumRoles.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSchema(int id)
        {
            var schema = await _context.Scheme.FindAsync(id);
            if (schema == null)
            {
                return NoContent();
            }
            try
            {
                _context.Scheme.Remove(schema);
                await _context.SaveChangesAsync();
                Ok(schema);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }

        private bool SchemaExists(int id)
        {
            return _context.Scheme.Any(e => e.Id == id);
        }
    }
}
