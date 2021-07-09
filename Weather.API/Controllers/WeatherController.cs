using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Weather.API.Models;

namespace Weather.API.Controllers
{
    public class WeatherController : Controller
    {
        private static readonly IWeatherRepository repository = new WeatherRepository();
        // GET: Weather
        public ActionResult Index()
        {
            return View();
        }

        public IEnumerable<WeatherData> GetAllWeather()
        {
            return repository.GetAll();
        }

        public WeatherData GetWeather(int id)
        {
            WeatherData requestedWeather = repository.Get(id);
            if(requestedWeather == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return requestedWeather;
        }

        public WeatherData GetWeatherDataByLocation(Location location)
        {
            return (WeatherData)repository.GetAll().Where(item => item.Location.Equals(location));
        }

        public HttpResponseMessage PostWeather(WeatherData newWeather)
        {
            newWeather = repository.Add(newWeather);
            HttpRequestMessage request = new HttpRequestMessage();
            var response = request.CreateResponse<WeatherData>(HttpStatusCode.Created, newWeather);

            string uri = Url.RouteUrl("DefaultApi", new { id = newWeather.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutWeatherData(int id, WeatherData weather)
        {
            weather.Id = id;
            if(!repository.Update(weather))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteWeather(int id)
        {
            WeatherData weather = repository.Get(id);
            if (weather == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }
    }
}