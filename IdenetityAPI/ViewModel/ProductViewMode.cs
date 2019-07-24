using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdenetityAPI.ViewModel
{
    public class ProductViewMode
    {

       
        public int ProductId { get; set; }
        public string productName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }

        public int CatId { get; set; }
    }
}