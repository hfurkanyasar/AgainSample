using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TekrarSample._01.UI.Models
{
    public class HizirContext:DbContext
    {
        public HizirContext(DbContextOptions<HizirContext>opt):base(opt)
        {
            
        }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
    }
}
