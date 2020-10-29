using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Commands;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class TemperatureViewModel : BaseViewModel
    {
        // TODO : Ajoutez le code nécessaire pour réussir les tests et répondre aux requis du projet

        #region Variables---------------------------------------------------------------------------
        public ITemperatureService TemperatureService;

        public TemperatureModel CurrentTemp { get; set; }

        #endregion


        #region Command----------------------------------------------------------------------------
        public DelegateCommand<string> GetTempCommande { get; set; }

        #endregion


        #region Constructeur-----------------------------------------------------------------------
        public TemperatureViewModel()
        {
            GetTempCommande = new DelegateCommand<string>(GetTemp, CanGetTemp);
        }

        #endregion


        #region Methode Utiliataire----------------------------------------------------------------
        public void SetTemperatureService(ITemperatureService service) {
            TemperatureService = service;
        }



        public async Task GetTempAsync(String T)
        {
            CurrentTemp = await TemperatureService.GetTempAsync();
        }
        #endregion


        #region Methodes Command-------------------------------------------------------------------

        public void GetTemp(String T)
        {
            if (TemperatureService == null)
                throw new NullReferenceException();
            else
                GetTempAsync(string.Empty);  
        }
        
        public bool CanGetTemp(String T)
        {
            if (TemperatureService == null) return false;
            else return true;
        }

        #endregion


        #region Static methode---------------------------------------------------------------------
        public static double CelsiusInFahrenheit(double c)
        {
            //𝑇𝑓 = 𝑇𝑐 × 9/5 + 32
            
            return Math.Round((c * 9 / 5 + 32), 1);
        }


        public static double FahrenheitInCelsius(double f)
        {
            //𝑇𝑐 = (𝑇𝑓 − 32) × (5/9)
            
            return Math.Round(( (f - 32) * 5 / 9 ), 1);
        }
        #endregion
    }
}
