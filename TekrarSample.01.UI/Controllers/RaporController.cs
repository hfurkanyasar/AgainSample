using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekrarSample._01.UI.Models;

namespace TekrarSample._01.UI.Controllers
{
    public class RaporController : Controller
    {
        private readonly HizirContext _cnn;
        public RaporController(HizirContext cnn)
        {
            _cnn = cnn;
        }
        public IActionResult Index()
        {
            var joinData = (from u in _cnn.Uruns
                            join k in _cnn.Kategoris
                            on u.KategoriID equals k.KategoriID

                            select new Rapor
                            {
                                KategoriAdi=k.KategoriAdi,
                                UrunAdi=u.UrunAdi,
                                 UrunFİyati=u.UrunFİyati,
                                 UrunStokAdeti=u.UrunStokAdeti

                            }).ToList();

            
            return View(joinData);
        }
    }
}
