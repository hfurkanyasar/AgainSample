using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekrarSample._01.UI.Models;

namespace TekrarSample._01.UI.Controllers
{
    public class UrunController : Controller
    {
        private readonly HizirContext _cnn;
        public UrunController(HizirContext cnn)
        {
            _cnn = cnn;
        }
        public IActionResult Index()
        {
            var data = _cnn.Uruns.ToList();
            return View(data);
        }

        public IActionResult ekleUrun()
        {


            return View();
        }
        [HttpPost]
        public IActionResult ekleUrun(Urun urun)
        {
            var data = _cnn.Uruns.FirstOrDefault(a => a.UrunAdi == urun.UrunAdi);
            if (data == null)
            {
                _cnn.Uruns.Add(urun);
                var dataOK = _cnn.SaveChanges();
                if (dataOK > 0)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Hata");
            }
            return RedirectToAction("Hata");
        }

        public IActionResult silUrun(int id)
        {
            var delData = _cnn.Uruns.Find(id);
            if (delData == null)
            {
                return RedirectToAction("Hata");
            }

            _cnn.Remove(delData);
            var okData = _cnn.SaveChanges();
            if (okData > 0)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Hata");
        }



        public IActionResult guncelleUrun(int id)
        {
            var uppData = _cnn.Uruns.SingleOrDefault(a => a.KategoriID == id);

            return View(uppData);
        }
        [HttpPost]
        public IActionResult guncelleUrun(Urun urun)
        {
            var data = _cnn.Uruns.SingleOrDefault(a => a.KategoriID == urun.KategoriID);
            data.UrunAdi = urun.UrunAdi;
            data.UrunFİyati = urun.UrunFİyati;
            data.UrunStokAdeti = urun.UrunStokAdeti;
            var dataOK = _cnn.SaveChanges();
            if (dataOK > 0)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Hata");
        }


        public IActionResult Gedebidiget()
        {
            //List<SelectListItem> datas = new List<SelectListItem>();
            var data = _cnn.Kategoris.Select(a => new SelectListItem
            {


                Text = a.KategoriAdi,
                Value = a.KategoriID.ToString()

            }).ToList();
            UrunWithCategoryVM datas = new UrunWithCategoryVM() {

                KategoriListesi = data
            
            
            };
            return View(datas);
        }
        [HttpPost]
        public IActionResult Gedebidiget(UrunWithCategoryVM vm)
        {
            Urun urun = new Urun();
            urun.KategoriID = vm.KategoriID;
            urun.UrunFİyati = vm.UrunFİyati;
            urun.UrunStokAdeti = vm.UrunStokAdeti;
            urun.UrunAdi = vm.UrunAdi;
            _cnn.Uruns.Add(urun);
            var data = _cnn.SaveChanges();
            return RedirectToAction("Gedebidiget");
        }




    }
}

