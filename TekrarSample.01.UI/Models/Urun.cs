using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TekrarSample._01.UI.Models
{
    public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public decimal UrunFİyati { get; set; }
        public string UrunStokAdeti { get; set; }


        public int KategoriID { get; set; }

        [ForeignKey("KategoriID")]
        public Kategori Kategori { get; set; }
    }
}
