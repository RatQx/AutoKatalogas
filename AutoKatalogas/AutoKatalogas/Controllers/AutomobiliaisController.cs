using AutoKatalogas.Auth.Model;
using AutoKatalogas.Data;
using AutoKatalogas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Linq;
using System.Security.Claims;
using static AutoKatalogas.Models.Automobiliai;

namespace AutoKatalogas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomobiliaisController : ControllerBase
    {
        private ApiContext _context;
        private readonly IAuthorizationService _authorizationService;

        public AutomobiliaisController(ApiContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            _authorizationService = authorizationService;
        }

        // GET: api/Automobiliais
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent , Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Automobiliai>>> GetAutos()
        {
            try
            {
                var list = await _context.Autos.ToListAsync();
                Ok(list);
                return list;
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // GET: api/Automobiliais/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Automobiliai>> GetAutomobiliai(int id)
        {
            try
            {
                var automobiliai = await _context.Autos.FindAsync(id);
                if(automobiliai==null)
                {
                    return NoContent();
                }
                Ok(automobiliai);
                return automobiliai;
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // PUT: api/Automobiliais/5
        [HttpPut("{id}")]
        [Authorize(Roles = ForumRoles.ForumUser)]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAutomobiliai(int id, AutomobiliaiCreateReq automobiliai)
        {
            if (id != automobiliai.id)
            {
                NoContent();
            }
            var pav = await _context.Autos.FindAsync(id);
            if (pav == null)
            {
                NoContent();
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
            if (automobiliai.Production_date != null && automobiliai.Production_date<= DateTime.Now)
            {
                pav.Production_date = automobiliai.Production_date;
            }

            var  authorizationResult = await _authorizationService.AuthorizeAsync(User, pav, PolicyNames.ResourceOwner);
            if(!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            try
            {
                await _context.SaveChangesAsync();
                Ok(automobiliai);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutomobiliaiExists(id))
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }

           return Ok();
        }

        // POST: api/Automobiliais
        [HttpPost]
        [Authorize(Roles = ForumRoles.ForumUser)]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Automobiliai>> PostAutomobiliai(AutomobiliaiCreateReq automobiliai)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (automobiliai == null)
            {
                return NoContent();
            }

            if (automobiliai.Production_date != null 
                && automobiliai.Production_date <= DateTime.Now
                && automobiliai.Marke!=null
                && automobiliai.Model!=null
                && automobiliai.Vin!=null)
            {
                try
                {
                    var autoEntity = automobiliai.ToAutomobiliai();
                    autoEntity.UserId = userId;
                    _context.Autos.Add(autoEntity);
                    await _context.SaveChangesAsync();
                    Created(nameof(automobiliai), automobiliai);

                    return CreatedAtAction("GetAutomobiliai", new { id = automobiliai.id }, automobiliai);
                }
                catch (Exception ex)
                {
                    return NotFound();
                }
            }
            return Ok();
            
        }

        // DELETE: api/Automobiliais/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAutomobiliai(int id)
        {
            var automobiliai = await _context.Autos.FindAsync(id);
            if (automobiliai == null)
            {
                return NoContent();
            }
            try
            {
                _context.Autos.Remove(automobiliai);
                await _context.SaveChangesAsync();
                Ok(automobiliai);

            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return Ok();
        }

        private bool AutomobiliaiExists(int id)
        {
            return _context.Autos.Any(e => e.id == id);
        }

        // GET: api/Automobiliai/{id}/Dalys
        [HttpGet("{id}/Dalys")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Dalys>>> GetDalysByAutoId(int id)
        {
            try
            {
                var parts = _context.Parts
                       .Where(x => x.AutomobilioId == id)
                       .ToList();
                if (parts == null || parts.Count == 0)
                {
                    return NoContent();
                }
                return parts;

            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // GET: api/Automobiliai/{id}/Dalys
        [HttpGet("{autoId}/Dalys/{partId}/Aprasymas")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Automobiliai))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Aprasymas>>> GetDescByAutoId(int autoId, int partId)
        {
            try
            {
                var parts = _context.Parts
                    .Where(x => x.AutomobilioId == autoId)
                    .Select(x => x.Id)
                    .ToList();

                var desc = _context.Descriptions
                    .Where(x => x.DalisId == (partId) && parts.Contains(partId))
                    .ToList();

                if (desc == null || desc.Count() == 0)
                {
                    return NoContent();
                }
                return desc;

            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
   
}
