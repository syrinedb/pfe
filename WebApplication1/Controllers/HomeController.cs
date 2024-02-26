using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
       
         public async Task <IActionResult> GetWeatherDetails(string Latitude , string Longitude, string Forecast_days, string Past_days,string cardmod)
        {
            WeatherService weatherService = new WeatherService();
            var response = await weatherService.GetWeatherData(Latitude,Longitude,Forecast_days,Past_days,cardmod);
            var responseMeteo = JsonConvert.SerializeObject(response.JsonData);
            ViewData["ApiResponse"] = responseMeteo;
            var apiResponse = ViewData["ApiResponse"] as string;
            var responseData = JsonConvert.DeserializeObject<Meteo>(apiResponse);
            var temperature = responseData.hourly.temperature_2m;
            var time = responseData.hourly.time;
            return View("Index");
            
        }
        public IActionResult Scartter()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    
}
