using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VT_Lab1.DAL.Data;
using VT_Lab1.DAL.Entities;

namespace VT_Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TilesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tile>>> GetTilees(int? group)
        {
            return await _context
         .Tilees
         .Where(d => !group.HasValue
         || d.TileGroupId.Equals(group.Value))
         ?.ToListAsync();

        }

        // GET: api/Tiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tile>> GetTile(int id)
        {
            var tile = await _context.Tilees.FindAsync(id);

            if (tile == null)
            {
                return NotFound();
            }

            return tile;
        }

        // PUT: api/Tiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTile(int id, Tile tile)
        {
            if (id != tile.TileId)
            {
                return BadRequest();
            }

            _context.Entry(tile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tile>> PostTile(Tile tile)
        {
            _context.Tilees.Add(tile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTile", new { id = tile.TileId }, tile);
        }

        // DELETE: api/Tiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTile(int id)
        {
            var tile = await _context.Tilees.FindAsync(id);
            if (tile == null)
            {
                return NotFound();
            }

            _context.Tilees.Remove(tile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TileExists(int id)
        {
            return _context.Tilees.Any(e => e.TileId == id);
        }
    }
}
