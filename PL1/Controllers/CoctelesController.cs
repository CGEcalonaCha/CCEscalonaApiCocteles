using Microsoft.AspNetCore.Mvc;

using MySqlX.XDevAPI;
using System.Net;
using System.Text;

namespace PL1.Controllers
{
    public class CoctelesController : Controller
    {
        [HttpGet]
        public IActionResult Getall(ML.Cocteles coctele)
        {
            ML.Result resultcoctel = new ML.Result();
            resultcoctel.Objects = new List<object>();
            string letra = "Coctel";
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/json");
                var responseTask = client.GetAsync("json/v1/1/search.php?s=" + letra);
                responseTask.Wait();
                var resultAPI = responseTask.Result;
                if (resultAPI.IsSuccessStatusCode)
                {
                    var readTask = resultAPI.Content.ReadAsStringAsync();
                    readTask.Wait();
                    foreach (var resultItem in readTask.Result.)
                    {
                        ML.Cocteles resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Cocteles>(resultItem.ToString());
                        coctele.Cocteless.Add(resultItemList);
                    }
                }
                return View(coctele);
             }
        }
        
    }
}
