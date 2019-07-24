
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdenetityAPI.Models
{
    public class category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string ImgUrl { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> ProductLis { get; set; }
    }
}