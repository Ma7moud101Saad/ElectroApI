using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdenetityAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string productName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        [JsonIgnore]
        public virtual category CategoryObj { get; set; }
       
    }
}