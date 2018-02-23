using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Lunch
    {
        public List<SelectListItem> Menu { get; set; }
    }

    public class Items
    {
        public int Id;
        public string Item;
        public long rate;
    }
}