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

namespace CR_Proiect.Pages.Regine
{
    public class EditModel : PageModel
    {
        private readonly CR_Proiect.Data.CR_ProiectContext _context;

        public EditModel(CR_Proiect.Data.CR_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Regina Regina { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Regina == null)
            {
                return NotFound();
            }

            var regina =  await _context.Regina.FirstOrDefaultAsync(m => m.ID == id);
            if (regina == null)
            {
                return NotFound();
            }
            Regina = regina;
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

            _context.Attach(Regina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReginaExists(Regina.ID))
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

        private bool ReginaExists(int id)
        {
          return (_context.Regina?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
