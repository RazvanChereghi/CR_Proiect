using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CR_Proiect.Data;
using CR_Proiect.Models;

namespace CR_Proiect.Pages.Regine
{
    public class DetailsModel : PageModel
    {
        private readonly CR_Proiect.Data.CR_ProiectContext _context;

        public DetailsModel(CR_Proiect.Data.CR_ProiectContext context)
        {
            _context = context;
        }

      public Regina Regina { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Regina == null)
            {
                return NotFound();
            }

            var regina = await _context.Regina.FirstOrDefaultAsync(m => m.ID == id);
            if (regina == null)
            {
                return NotFound();
            }
            else 
            {
                Regina = regina;
            }
            return Page();
        }
    }
}
