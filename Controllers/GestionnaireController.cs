using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reservation_vols.Data;
using reservation_vols.Models;

namespace reservation_vols.Controllers
{
    [Route("api/gestionnaire")]
    [ApiController]
    public class GestionnaireController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GestionnaireController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/gestionnaire/vols
        [HttpGet("vols")]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVols()
        {
            return await _context.Vols.ToListAsync();
        }

        // GET: api/gestionnaire/vols/{id}
        [HttpGet("vols/{id}")]
        public async Task<ActionResult<Vol>> GetVol(int id)
        {
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
            {
                return NotFound(new { message = "Vol introuvable" });
            }
            return vol;
        }

        // POST: api/gestionnaire/ajouter-vol
        [HttpPost("ajouter-vol")]
        public async Task<ActionResult<Vol>> AjouterVol(Vol vol)
        {
            _context.Vols.Add(vol);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVol), new { id = vol.Id }, vol);
        }

        // PUT: api/gestionnaire/modifier-vol/{id}
        [HttpPut("modifier-vol/{id}")]
        public async Task<IActionResult> ModifierVol(int id, Vol vol)
        {
            if (id != vol.Id)
            {
                return BadRequest(new { message = "L'ID du vol ne correspond pas" });
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Vols.Any(v => v.Id == id))
                {
                    return NotFound(new { message = "Vol introuvable" });
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/gestionnaire/supprimer-vol/{id}
        [HttpDelete("supprimer-vol/{id}")]
        public async Task<IActionResult> SupprimerVol(int id)
        {
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
            {
                return NotFound(new { message = "Vol introuvable" });
            }

            _context.Vols.Remove(vol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/gestionnaire/rechercher-vols?destination=Paris&prixMin=100&prixMax=500
        [HttpGet("rechercher-vols")]
        public async Task<ActionResult<IEnumerable<Vol>>> RechercherVols(
            [FromQuery] string destination = null,
            [FromQuery] DateTime? dateDepart = null,
            [FromQuery] float? prixMin = null,
            [FromQuery] float? prixMax = null)
        {
            var query = _context.Vols.AsQueryable();

            if (!string.IsNullOrEmpty(destination))
                query = query.Where(v => v.destination.Contains(destination));

            if (dateDepart.HasValue)
                query = query.Where(v => v.dateDepart.Date == dateDepart.Value.Date);

            if (prixMin.HasValue)
                query = query.Where(v => v.prix >= prixMin.Value);

            if (prixMax.HasValue)
                query = query.Where(v => v.prix <= prixMax.Value);

            var result = await query.ToListAsync();

            if (result.Count == 0)
                return NotFound(new { message = "Aucun vol trouvé avec ces critères" });

            return result;
        }
    }
}
