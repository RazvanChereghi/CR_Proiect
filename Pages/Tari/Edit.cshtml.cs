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

namespace CR_Proiect.Pages.Tari
{
    public class EditModel : PageModel
    {
        private readonly CR_Proiect.Data.CR_ProiectContext _context;

        public EditModel(CR_Proiect.Data.CR_ProiectContext context)
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

            var tara =  await _context.Tara.FirstOrDefaultAsync(m => m.ID == id);
            if (tara == null)
            {
                return NotFound();
            }
            Tara = tara;
            ViewData["BisericaID"] = new SelectList(_context.Biserica, "ID", "Name");
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

            _context.Attach(Tara).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaraExists(Tara.ID))
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

        private bool TaraExists(int id)
        {
          return (_context.Tara?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
