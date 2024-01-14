using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CR_Proiect.Models;

namespace CR_Proiect.Data
{
    public class CR_ProiectContext : DbContext
    {
        public CR_ProiectContext (DbContextOptions<CR_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<CR_Proiect.Models.Biserica> Biserica { get; set; } = default!;

        public DbSet<CR_Proiect.Models.Rege>? Rege { get; set; }

        public DbSet<CR_Proiect.Models.Regina>? Regina { get; set; }

        public DbSet<CR_Proiect.Models.Tara>? Tara { get; set; }
    }
}
