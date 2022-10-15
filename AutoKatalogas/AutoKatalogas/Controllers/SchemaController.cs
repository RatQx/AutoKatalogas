using AutoKatalogas.Data;
using AutoKatalogas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<Schema>>> GetScheme()
        {
            try
            {
                return await _context.Scheme.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.ToString());
            }
        }

        // GET: api/Schema/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schema>> GetSchema(int id)
        {
            try
            {
                var schema = await _context.Scheme.FindAsync(id);
                if (schema == null)
                {
                    throw new ArgumentNullException(nameof(schema));
                }
                return schema;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.ToString());
            }
        }

        // PUT: api/Schema/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchema(int id, Schema schema)
        {
            if (id != schema.Id)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var pav = await _context.Scheme.FindAsync(id);
            if (pav == null)
            {
                throw new ArgumentNullException(nameof(schema));
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
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchemaExists(id))
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

        // POST: api/Schema
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Schema>> PostSchema(SchemaCreateReq schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
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

                        return CreatedAtAction("GetSchema", new { id = schema.Id }, schema);
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentNullException(ex.ToString());
                    }
                }
            }
            return NoContent();
        }

        // DELETE: api/Schema/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchema(int id)
        {
            var schema = await _context.Scheme.FindAsync(id);
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            try
            {
                _context.Scheme.Remove(schema);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.ToString());
            }
            return NoContent();
        }

        private bool SchemaExists(int id)
        {
            return _context.Scheme.Any(e => e.Id == id);
        }
    }
}
