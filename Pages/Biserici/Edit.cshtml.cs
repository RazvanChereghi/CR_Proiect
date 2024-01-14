using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CR_Proiect.Data;
using CR_Proiect.Models;

namespace CR_Proiect.Pages.Biserici
{
    public class EditModel : PageModel
    {
        private readonly CR_Proiect.Data.CR_ProiectContext _context;

        public EditModel(CR_Proiect.Data.CR_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Biserica Biserica { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Biserica == null)
            {
                return NotFound();
            }

            var biserica = await _context.Biserica
                .Include(b => b.Rege)
                .Include(b => b.Regina)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (biserica == null)
            {
                return NotFound();
            }
            Biserica = biserica;
            ViewData["RegeID"] = new SelectList(_context.Set<Rege>(), "ID", "Name");
            ViewData["ReginaID"] = new SelectList(_context.Set<Regina>(), "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Biserica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BisericaExists(Biserica.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BisericaExists(int id)
        {
            return (_context.Biserica?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
