using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.API.Models
{
    public class WeatherRepository : IWeatherRepository
    {
        private List<WeatherData> allWeather = new List<WeatherData>();
        private int _nextId = 1;

        public WeatherRepository()
        {
            decimal[] temprature = new decimal[] { 37.3M, 36.8M, 36.4M, 36.0M,35.3M,35.8M,38.6M, 37.3M, 36.8M, 36.4M, 36.0M, 35.3M, 35.8M, 38.6M, 37.3M, 36.8M, 36.4M, 36.0M, 35.3M, 35.8M, 38.6M,36.1M };

            Add(new WeatherData { Id = 1, Date = "1985 - 01 - 01", Location = new Location { lat = (decimal)36.1189, lon = (decimal)-86.6892, Name = "Palo Alto", State = "California" },
                Temprature = temprature
            });
        }
        public WeatherData Add(WeatherData newWeather)
        {
            if(newWeather == null)
            {
                throw new ArgumentNullException();
            }
            newWeather.Id = _nextId++;
            allWeather.Add(newWeather);
            return newWeather;
        }

        public WeatherData Get(int id)
        {
            return allWeather.Find(item => item.Id == id);
        }

        public IEnumerable<WeatherData> GetAll()
        {
            return allWeather;
        }

        public void Remove(int id)
        {
            allWeather.RemoveAll(item => item.Id == id);
        }

        public bool Update(WeatherData weather)
        {
            if(weather == null)
            {
                throw new ArgumentNullException("weather");
            }
            int index = allWeather.FindIndex(item => item.Id == weather.Id);
            if(index == -1)
            {
                return false;
            }
            allWeather.RemoveAt(index);
            allWeather.Add(weather);
            return true;
        }
    }
}