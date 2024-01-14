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
    public class IndexModel : PageModel
    {
        private readonly CR_Proiect.Data.CR_ProiectContext _context;

        public IndexModel(CR_Proiect.Data.CR_ProiectContext context)
        {
            _context = context;
        }

        public IList<Biserica> Biserica { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Biserica != null)
            {
                Biserica = await _context.Biserica
                    .Include(b => b.Rege)
                    .Include(b => b.Regina)
                    .ToListAsync();
            }
        }
    }
}
