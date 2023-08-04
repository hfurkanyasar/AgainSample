using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TekrarSample._01.UI.Models
{
    public class Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }

        public List<Urun> Uruns { get; set; }
    }
}
