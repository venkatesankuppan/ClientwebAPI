using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
namespace WebApi1.Controllers
{
    public class LunchController : ApiController
    {

        private static List<Items> GetLunchItems()
        {
            List<Items> objrate = new List<Items>();
            objrate.Add(new Items { Id = 1, Item = "Dosa", rate = 30 });
            objrate.Add(new Items { Id = 2, Item = "Biriyani", rate = 120 });
            objrate.Add(new Items { Id = 3, Item = "Meals", rate = 80 });
            objrate.Add(new Items { Id = 4, Item = "Mini Meals", rate = 50 });
            objrate.Add(new Items { Id = 5, Item = "Chappathi", rate = 40 });
            return objrate;
        }


        
        //[System.Web.Http.HttpGet]
        //[System.Web.Http.Route("api/Lunch/Menu")]
        //public string Menu()
        //{
        //    string[] menu = { "Dosa", "Biriyani", "Meals" };
        //    var res =  JsonConvert.SerializeObject(menu);

        //    return res;
        //}

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Lunch/Items")]
        public List<Items> Items()
        {
            List<Items> objrate = GetLunchItems();            
            return objrate;

        }

       
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Lunch/Items/GetRate")]
        public long GetRate(int Id)
        {
            List<Items> objrate = GetLunchItems();

            var sel = from item in objrate
                      where item.Id.Equals(Id)
                      select item;

           return sel.FirstOrDefault<Items>().rate;

        }

        //[System.Web.Http.HttpGet]
        //[System.Web.Http.Route("api/Lunch/Items/GetRate")]
        //public HttpResponseMessage GetRate(int Id)
        //{
        //    List<Items> objrate = GetLunchItems();

        //    var sel = from item in objrate
        //              where item.Id.Equals(Id)
        //              select item;
        //    var result = sel.FirstOrDefault<Items>().rate;
        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
        //    return response;

        //}
    }

    public class Items
    {
        public int Id;
        public string Item;
        public long rate;
    }
}