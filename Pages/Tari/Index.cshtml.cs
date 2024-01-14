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
    public class IndexModel : PageModel
    {
        private readonly CR_Proiect.Data.CR_ProiectContext _context;

        public IndexModel(CR_Proiect.Data.CR_ProiectContext context)
        {
            _context = context;
        }

        public IList<Tara> Tara { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tara != null)
            {
                Tara = await _context.Tara
                .Include(t => t.Biserica)
                .ThenInclude(t => t.Regina)
                .Include(t => t.Biserica)
                .ThenInclude(t => t.Rege)
                .ToListAsync();
            }
        }
    }
}
