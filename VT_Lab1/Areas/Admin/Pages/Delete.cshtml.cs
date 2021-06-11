using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VT_Lab1.DAL.Data;
using VT_Lab1.DAL.Entities;

namespace VT_Lab1.Areas.Admin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly VT_Lab1.DAL.Data.ApplicationDbContext _context;

        public DeleteModel(VT_Lab1.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tile Tile { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tile = await _context.Tilees
                .Include(t => t.Group).FirstOrDefaultAsync(m => m.TileId == id);

            if (Tile == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tile = await _context.Tilees.FindAsync(id);

            if (Tile != null)
            {
                _context.Tilees.Remove(Tile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
