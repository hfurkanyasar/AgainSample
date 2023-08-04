using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TekrarSample._01.UI.Models
{
    public class UrunWithCategoryVM
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public decimal UrunFİyati { get; set; }
        public string UrunStokAdeti { get; set; }

        public List<SelectListItem> KategoriListesi { get; set; }

        public int KategoriID { get; set; }
    }
}
