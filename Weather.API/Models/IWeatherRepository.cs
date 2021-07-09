using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.API.Models
{
    public interface IWeatherRepository
    {
        IEnumerable<WeatherData> GetAll();
        WeatherData Get(int id);
        WeatherData Add(WeatherData newWeather);
        void Remove(int id);
        bool Update(WeatherData weather);
    }
}
