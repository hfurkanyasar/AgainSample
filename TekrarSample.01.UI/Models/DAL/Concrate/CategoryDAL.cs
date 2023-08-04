using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekrarSample._01.UI.Models.DAL.Interfaces;

namespace TekrarSample._01.UI.Models.DAL.Concrate
{
    public class CategoryDAL : ICategoryDAL
    {
        HizirContext _cnn;
        public CategoryDAL(HizirContext cnn)
        {
            _cnn = cnn;
        }
        public List<SelectListItem> SelectCategory()
        {
            var data = _cnn.Kategoris.Select(a => new SelectListItem
            {


                Text = a.KategoriAdi,
                Value = a.KategoriID.ToString()

            }).ToList();
            return data;
        }
    }
}
