using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Commands;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class TemperatureViewModel : BaseViewModel
    {
        /// TODO : Ajoutez le code nécessaire pour réussir les tests et répondre aux requis du projet
        #region Variables---------------------------------------------------------------------------
        //readonly TemperatureService customersDataService = new CustomersDataService();
        public TemperatureModel CurrentTemp { get; set; }

        #endregion


        #region Command----------------------------------------------------------------------------
        DelegateCommand<string> GetTempCommand;

        #endregion


        #region Constructeur-----------------------------------------------------------------------
        public TemperatureViewModel()
        {
            GetTempCommand = new DelegateCommand<string>(GetTemp, CanGetTemp);
        }

        #endregion


        #region Methodes Command-------------------------------------------------------------------

        public void GetTemp(String T)
        {
           
        }
        
        public bool CanGetTemp(String T)
        {
            return true;
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
