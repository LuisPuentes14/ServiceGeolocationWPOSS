using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGeolocationWPOSS.Services
{
    public class ServiceGeolocation
    {
        public  string GetGeolocalization()
        {
            string resultJson = null;
            try
            {
                var options = new ChromeOptions();

                //options.SetLoggingPreference(LogType.Browser, LogLevel.All);

                // Activar el modo sin cabeza
                //options.AddArgument("--headless");
                options.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 1); // 1 significa permitir

                var driver = new ChromeDriver(options);

                driver.Navigate().GoToUrl("https://www.google.com");

                IJavaScriptExecutor jsExecutor = driver;

                var script = @"
            return new Promise((resolve, reject) => {
                navigator.geolocation.getCurrentPosition(
                    function(position) {
                        resolve({latitude: position.coords.latitude, longitude: position.coords.longitude});
                    },
                    function(error) {
                        reject('Geolocation error: ' + error.message);
                    }
                );
            });";

                var result = jsExecutor.ExecuteScript(script);


                if (result is Dictionary<string, object> location)
                {
                    resultJson = "{\"latitude\": \"" + location["latitude"] + "\", \"longitude\" : \"" + location["longitude"] + "\" }";
                    Console.WriteLine($"Latitude: {location["latitude"]}, Longitude: {location["longitude"]}");
                }

                driver.Manage().Window.Minimize();

                // Asegúrate de cerrar el navegador después de obtener la información necesaria
                driver.Quit();

            }
            catch (Exception ex)
            {
                // FileLog.WriteLog(ex.Message);


            }

            return resultJson;

        }
    }
}
