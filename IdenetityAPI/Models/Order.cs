using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdenetityAPI.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int TotalCoast { get; set; }
        public string Date { get; set; }
        [ForeignKey("IdentityUser")]
        public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}