using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> Menu1()
        {
            string Baseurl = "http://localhost:91/";
            List<Items> LunchItems = new List<Items>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("/api/Lunch/Items");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var apiresult = Res.Content.ReadAsStringAsync().Result;

                   // var res = JsonConvert.DeserializeObject(apiresult);

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    LunchItems = JsonConvert.DeserializeObject<List<Items>>(apiresult);
                }
                
            }

            Lunch objlunch = new Lunch();
            var menu = new List<SelectListItem>(LunchItems.Count);

            foreach (Items items in LunchItems)
            {
                menu.Add(new SelectListItem { Text = items.Item , Value = items.Id.ToString() });
            
            }
            
            

            objlunch.Menu = menu;

            ViewBag.Message = "my new menu1 page.";

            return View(objlunch);
        }
    }
}