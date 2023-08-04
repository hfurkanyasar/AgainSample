using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekrarSample._01.UI.Models;

namespace TekrarSample._01.UI.Controllers
{
    public class OrnekController : Controller
    {
        HizirContext _cnn;
        public OrnekController(HizirContext cnn)
        {
            _cnn = cnn;
        }
        public IActionResult Index()
        {
            var result = _cnn.Kategoris.ToList();
            return View(result);
        }
        public IActionResult ekleKat()
        {

            return View(new Kategori());
        }
        [HttpPost]
        public IActionResult ekleKat([Bind("KategoriAdi")] Kategori kat)
        {
            var data = _cnn.Kategoris.FirstOrDefault(x => x.KategoriAdi == kat.KategoriAdi);

            if (data == null)
            {
                _cnn.Kategoris.Add(kat);
                var dataOk = _cnn.SaveChanges();
                if (dataOk > 0)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Hata");
            }


            return RedirectToAction("Hata");

        }
        public IActionResult Hata()
        {
            ViewBag.ErrorMessage = TempData["Message"];
            return View();
        }
        public IActionResult guncelleKat(int id)
        {
            var güncellenenData = _cnn.Kategoris.SingleOrDefault(a => a.KategoriID == id);

            return View(güncellenenData);
        }
        [HttpPost]
        public IActionResult guncelleKat(Kategori kat)
        {
            var uppData = _cnn.Kategoris.Where(a => a.KategoriID == kat.KategoriID).SingleOrDefault();
            uppData.KategoriAdi = kat.KategoriAdi;
            var okData = _cnn.SaveChanges();
            if (okData > 0)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Hata");
        }
        public IActionResult silKat(int id)
        {
            var data = _cnn.Kategoris.SingleOrDefault(a => a.KategoriID == id);
            _cnn.Remove(data);
            var datadelok = _cnn.SaveChanges();
            if (datadelok > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Hata");
            }


        }

        public IActionResult Hede()
        {
            
            return View(new CategoryModel());
        }
        [HttpPost]
        public IActionResult Hede(CategoryModel cat)
        {

            return View();
        }


    }
}
