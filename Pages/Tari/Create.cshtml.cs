using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CR_Proiect.Data;
using CR_Proiect.Models;

namespace CR_Proiect.Pages.Tari
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
        ViewData["BisericaID"] = new SelectList(_context.Biserica, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Tara Tara { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tara == null || Tara == null)
            {
                return Page();
            }

            _context.Tara.Add(Tara);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
