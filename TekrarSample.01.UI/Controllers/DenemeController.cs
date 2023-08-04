using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekrarSample._01.UI.Models;

namespace TekrarSample._01.UI.Controllers
{
    public class DenemeController : Controller
    {
        private readonly IConfiguration _conf;
        public DenemeController(IConfiguration conf)
        {
            _conf=conf;
        }
        public IActionResult Index()
        {
            var urun = new Urunler
            {
                UrunAdi = _conf.GetSection("Urunler:ad").Value,
                UrunFİyati=decimal.Parse(_conf.GetSection("Urunler:fiyatı").Value)


            };
            return View();
        }
    }
}
