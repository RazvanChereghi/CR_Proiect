using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CR_Proiect.Data;
using CR_Proiect.Models;

namespace CR_Proiect.Pages.Regi
{
    public class CreateModel : PageModel
    {
        private readonly CR_Proiect.Data.CR_ProiectContext _context;

        public CreateModel(CR_Proiect.Data.CR_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Rege Rege { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Rege == null || Rege == null)
            {
                return Page();
            }

            _context.Rege.Add(Rege);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
