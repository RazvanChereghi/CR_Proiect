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

namespace CR_Proiect.Pages.Regi
{
    public class EditModel : PageModel
    {
        private readonly CR_Proiect.Data.CR_ProiectContext _context;

        public EditModel(CR_Proiect.Data.CR_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rege Rege { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rege == null)
            {
                return NotFound();
            }

            var rege =  await _context.Rege.FirstOrDefaultAsync(m => m.ID == id);
            if (rege == null)
            {
                return NotFound();
            }
            Rege = rege;
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

            _context.Attach(Rege).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegeExists(Rege.ID))
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

        private bool RegeExists(int id)
        {
          return (_context.Rege?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
