using Moq;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using Xunit;
using Xunit.Sdk;

namespace WeatherStationTests
{
    public class TemperatureViewModelTests : IDisposable
    {
        // System Under Test
        // Utilisez ce membre dans les tests
        //TemperatureViewModel _sut = new TemperatureViewModel();

        #region (ok) T01 Conversion Celsius -> Fahrenheit
        // <summary>
        // Test la fonctionnalité de conversion de Celsius à Fahrenheit
        // TODO : git commit -a -m "T01 CelsisInFahrenheit_AlwaysReturnGoodValue : Done"
        // </summary>
        // <param name="C">Degré Celsius</param>
        // <param name="expected">Résultat attendu</param>
        // <remarks>T01</remarks>
        
        [Theory]
        [InlineData(0, 32)]
        [InlineData(-40, -40)]
        [InlineData(-20, -4)]
        [InlineData(-17.8, 0)]
        [InlineData(37, 98.6)]
        [InlineData(100, 212)]

        public void CelsisInFahrenheit_AlwaysReturnGoodValue(double C, double expected)
        {
            // Arrange
          
            // Act       
            var actual = TemperatureViewModel.CelsiusInFahrenheit(C);

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion


        #region (ok) T02 Conversion Fahrenheit -> Celcius
        // <summary>
        // Test la fonctionnalité de conversion de Fahrenheit à Celsius
        // TODO : git commit -a -m "T02 FahrenheitInCelsius_AlwaysReturnGoodValue : Done"
        // </summary>
        // <param name="F">Degré F</param>
        // <param name="expected">Résultat attendu</param>
        // <remarks>T02</remarks>
        
        [Theory]
        [InlineData(32, 0)]
        [InlineData(-40, -40)]
        [InlineData(-4, -20)]
        [InlineData(0, -17.8)]
        [InlineData(98.6, 37)]
        [InlineData(212, 100)]

        public void FahrenheitInCelsius_AlwaysReturnGoodValue(double F, double expected)
        {
            // Arrange

            // Act       
            var actual = TemperatureViewModel.FahrenheitInCelsius(F);

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion


        #region () T03 GetTempCommand -> null si pas de service
        // <summary>
        // Lorsqu'exécuté GetTempCommand devrait lancer une NullException
        // TODO : git commit -a -m "T03 GetTempCommand_ExecuteIfNullService_ShouldThrowNullException : Done"
        // </summary>
        // <remarks>T03</remarks>
        [Fact]
        public void GetTempCommand_ExecuteIfNullService_ShouldThrowNullException()
        {
            // Arrange
            TemperatureViewModel _sut = new TemperatureViewModel();

            // Act       

            // Assert
            Assert.Throws<NullReferenceException>(() => _sut.GetTempCommande.Execute(string.Empty));  
        }
        #endregion


        #region (ok) T04 CanGetTemp -> false si pas de service
        // <summary>
        // La méthode CanGetTemp devrait retourner faux si le service est null
        // TODO : git commit -a -m "T04 CanGetTemp_WhenServiceIsNull_ReturnsFalse : Done"
        // </summary>
        // <remarks>T04</remarks>
        [Fact]
        public void CanGetTemp_WhenServiceIsNull_ReturnsFalse()
        {
            // Arrange
            TemperatureViewModel _sut = new TemperatureViewModel();

            // Act       
            var expected = false;
            var actual = _sut.GetTempCommande.CanExecute(String.Empty);

            // Assert
            Assert.Equal(expected, actual);

        }
        #endregion


        #region (ok) T05 CanGetTemp -> true si service instancier
        // <summary>
        // La méthode CanGetTemp devrait retourner vrai si le service est instancié
        // TODO : git commit -a -m "T05 CanGetTemp_WhenServiceIsSet_ReturnsTrue : Done"
        // </summary>
        // <remarks>T05</remarks>
        [Fact]
        public void CanGetTemp_WhenServiceIsSet_ReturnsTrue()
        {
            // Arrange
            TemperatureViewModel _sut = new TemperatureViewModel();
            Mock<ITemperatureService> _mockService = new Mock<ITemperatureService>();

            // Act   
            var expected = true;
            _sut.SetTemperatureService(_mockService.Object);   //Setter un service par le Mock
            var actual = _sut.GetTempCommande.CanExecute(String.Empty);

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion


        #region (ok) T06 TempratureService != null avec SetTemperatureService execute
        // <summary>
        // TemperatureService ne devrait plus être null lorsque SetTemperatureService
        // TODO : git commit -a -m "T06 SetTemperatureService_WhenExecuted_TemperatureServiceIsNotNull : Done"
        // </summary>
        // <remarks>T06</remarks>
        [Fact]
        public void SetTemperatureService_WhenExecuted_TemperatureServiceIsNotNull()
        {
            // Arrange
            TemperatureViewModel _sut = new TemperatureViewModel();
            Mock<ITemperatureService> _mockService = new Mock<ITemperatureService>();

            // Act       
            _sut.SetTemperatureService(_mockService.Object);   //Setter un service par le Mock

            // Assert
            Assert.NotNull(_sut.TemperatureService);
        }
        #endregion


        #region (ok) T07 CurrentTemp valeur quand GetTempsCommand execute
        // <summary>
        // CurrentTemp devrait avoir une valeur lorsque GetTempCommand est exécutée
        // TODO : git commit -a -m "T07 GetTempCommand_HaveCurrentTempWhenExecuted_ShouldPass : Done"
        // </summary>
        // <remarks>T07</remarks>
        [Fact]
        public void GetTempCommand_HaveCurrentTempWhenExecuted_ShouldPass()
        {
            // Arrange
            TemperatureViewModel _sut = new TemperatureViewModel();
            //Mock<AuduinoTemperatureServiceTest> _mockService = new Mock<AuduinoTemperatureServiceTest>();
            Mock<ITemperatureService> _mockService = new Mock<ITemperatureService>();

            // Act  
            _mockService.Setup(x => x.GetTempAsync()).Returns(GetTestTempAsync());
            _sut.SetTemperatureService(_mockService.Object);
            _sut.GetTempCommande.Execute(string.Empty);

            // Assert
            Assert.NotNull(_sut.CurrentTemp);
        }



        private async Task<TemperatureModel> GetTestTempAsync()
        {
            TemperatureModel test =  new TemperatureModel() { DateTime = DateTime.Now, Temperature = 20.1 };
            return test;
        }
        #endregion


        #region (OK) Standart de test
        /// <summary>
        /// Ne touchez pas à ça, c'est seulement pour respecter les standards
        /// de test qui veulent que la classe de tests implémente IDisposable
        /// Mais ça peut être utilisé, par exemple, si on a une connexion ouverte, il
        /// faut s'assurer qu'elle sera fermée lorsque l'objet sera détruit
        /// </summary>
        public void Dispose()
        {
            // Nothing to here, just for Testing standards
        }
        #endregion 
    }
}
