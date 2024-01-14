using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CR_Proiect.Data;
using CR_Proiect.Models;

namespace CR_Proiect.Pages.Regi
{
    public class DeleteModel : PageModel
    {
        private readonly CR_Proiect.Data.CR_ProiectContext _context;

        public DeleteModel(CR_Proiect.Data.CR_ProiectContext context)
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

            var rege = await _context.Rege.FirstOrDefaultAsync(m => m.ID == id);

            if (rege == null)
            {
                return NotFound();
            }
            else 
            {
                Rege = rege;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Rege == null)
            {
                return NotFound();
            }
            var rege = await _context.Rege.FindAsync(id);

            if (rege != null)
            {
                Rege = rege;
                _context.Rege.Remove(Rege);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
