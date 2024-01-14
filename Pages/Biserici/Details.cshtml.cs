using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CR_Proiect.Data;
using CR_Proiect.Models;

namespace CR_Proiect.Pages.Biserici
{
    public class DetailsModel : PageModel
    {
        private readonly CR_Proiect.Data.CR_ProiectContext _context;

        public DetailsModel(CR_Proiect.Data.CR_ProiectContext context)
        {
            _context = context;
        }

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
            else 
            {
                Biserica = biserica;
            }
            return Page();
        }
    }
}
