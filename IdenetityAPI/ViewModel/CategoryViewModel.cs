using IdenetityAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IdenetityAPI.ViewModel
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [DisplayName("Upload File")]
        public string ImgUrl { get; set; }
        public HttpPostedFile imageFile { get; set; }
        [JsonIgnore]
        public virtual ICollection<Product> ProductLis { get; set; }
        

    }
}