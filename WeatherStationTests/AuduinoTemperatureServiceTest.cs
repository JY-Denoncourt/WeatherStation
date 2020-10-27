using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherStationTests
{
    public class AuduinoTemperatureServiceTest : ITemperatureService
    {
        public Task<TemperatureModel> GetTempAsyn()
        {
            return null;
        }

        public TemperatureModel getTemp()
        {
            return new TemperatureModel() { DateTime= DateTime.Now, Temperature = 20.1 };
        }
    }
}
