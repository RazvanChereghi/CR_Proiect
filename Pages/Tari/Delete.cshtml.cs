using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CR_Proiect.Data;
using CR_Proiect.Models;

namespace CR_Proiect.Pages.Tari
{
    public class DeleteModel : PageModel
    {
        private readonly CR_Proiect.Data.CR_ProiectContext _context;

        public DeleteModel(CR_Proiect.Data.CR_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Tara Tara { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tara == null)
            {
                return NotFound();
            }

            var tara = await _context.Tara
                .Include(b => b.Biserica)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (tara == null)
            {
                return NotFound();
            }
            else 
            {
                Tara = tara;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tara == null)
            {
                return NotFound();
            }
            var tara = await _context.Tara.FindAsync(id);

            if (tara != null)
            {
                Tara = tara;
                _context.Tara.Remove(Tara);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
