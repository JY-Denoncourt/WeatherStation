﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    class AnduinoTemperatureService : ITemperatureService
    {
        public Task<TemperatureModel> GetTempAsyn()
        {
            return null;
        }
    }
}
