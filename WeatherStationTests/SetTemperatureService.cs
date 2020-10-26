using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherStationTests
{
    public class SetTemperatureService : ITemperatureService
    {
        public Task<TemperatureModel> GetTempAsyn()
        {
            return null;
        }
    }
}
