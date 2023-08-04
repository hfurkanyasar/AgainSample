using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekrarSample._01.UI.Models;
using TekrarSample._01.UI.Models.DAL.Interfaces;

namespace TekrarSample._01.UI.Controllers
{

    public class FarketmezController : Controller
    {
        IProductDAL _proDal;
        ICategoryDAL _catDal;
        public FarketmezController(ICategoryDAL catDal, IProductDAL proDal)
        {
            _catDal = catDal;
            _proDal = proDal;
        }

        public IActionResult Index()
        {
            //List<SelectListItem> datas = new List<SelectListItem>();



            UrunWithCategoryVM datas = new UrunWithCategoryVM()
            {

                KategoriListesi = _catDal.SelectCategory()


            };
            return View(datas);
        }
        [HttpPost]
        public IActionResult Index(UrunWithCategoryVM vm)
        {
            Urun urun = new Urun();
            urun.KategoriID = vm.KategoriID;
            urun.UrunFİyati = vm.UrunFİyati;
            urun.UrunStokAdeti = vm.UrunStokAdeti;
            urun.UrunAdi = vm.UrunAdi;
            _proDal.Ekleme(urun);
            return RedirectToAction("Gedebidiget");
        }
    }
}
