using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Weather.API.Models;

namespace Weather.API.Controllers
{
    public class WeatherDataController : ApiController
    {
        private static readonly IWeatherRepository repository = new WeatherRepository();
        // GET api/<controller>

        
        public IEnumerable<WeatherData> Get()
        {
            return repository.GetAll();
        }

        // GET api/<controller>/5
        public WeatherData Get(int id)
        {
            WeatherData requestedWeather = repository.Get(id);
            if (requestedWeather == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return requestedWeather;
        }
        public WeatherData GetWeatherDataByLocation(Location location)
        {
            return (WeatherData)repository.GetAll().Where(item => item.Location.Equals(location));
        }

        // POST api/<controller>
        public HttpResponseMessage Post(WeatherData newWeather)
        {
            newWeather = repository.Add(newWeather);
            HttpRequestMessage request = new HttpRequestMessage();
            var response = request.CreateResponse<WeatherData>(HttpStatusCode.Created, newWeather);

            string uri = Url.Link("DefaultApi", new { id = newWeather.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // PUT api/<controller>/5
        public void Put(int id, WeatherData weather)
        {
            weather.Id = id;
            if (!repository.Update(weather))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
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