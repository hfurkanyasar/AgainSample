using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekrarSample._01.UI.Models.DAL.Interfaces;

namespace TekrarSample._01.UI.Models.DAL.Concrate
{
    public class ProductDAL : IProductDAL
    {
        HizirContext _cnn;
        public ProductDAL(HizirContext cnn)
        {
            _cnn = cnn;
        }

        public void Ekleme(Urun urun)
        {
            _cnn.Uruns.Add(urun);
            _cnn.SaveChanges();
        }
    }
}
