using Flurl.Http;
using System.Net.Http;
using WebApplication1.Models;
namespace WebApplication1.Services

{
    public class WeatherService
    {
        public async Task<ResponseModel> GetWeatherData(string Lattitude, string Longitude,string Forecast_days, string Past_days, string cardmod)
        {
            WeatherModel weatherModel = new WeatherModel();
            weatherModel.meteo = new Meteo();
            weatherModel.modele = new Modele();


            Dictionary<string, object> query = new Dictionary<string, object>()
                {
                    { "latitude", Lattitude },
                    { "longitude", Longitude },
                    { "forecast_days", Forecast_days },
                    { "past_days", Past_days },
                    { "hourly", "temperature_2m" }
                };
             
             var queryString = string.Join("&", query.Select(kvp => $"{kvp.Key}={kvp.Value}"));
             string WeatherApiUrl = AppConstants.WeatherApiUrl;
           
             weatherModel.modele.GetMode(cardmod);
             string apiurl = $"{WeatherApiUrl}{weatherModel.modele.cardmod}?{queryString}";
            try
            {

                var response = await apiurl.GetAsync();
                if (response.StatusCode == 200)
                {
                    var responseData = await response.GetJsonAsync<WeatherModel>();
                    return ResponseModel.Success(responseData);
                }
                return ResponseModel.Error(response.ResponseMessage.ToString());
            }
            catch (FlurlHttpException ex)
            {
                var errorResponse = await ex.GetResponseJsonAsync<ResponseModel>();
                var responseModel = new ResponseModel
                {
                    IsSuccess = false,
                    Message = errorResponse?.Message, 
                };
                return responseModel;
            }

        }

    }
}
