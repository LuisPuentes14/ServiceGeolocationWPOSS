using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceGeolocationWPOSS.Services;

namespace ServiceGeolocationWPOSS.Works
{
    public class WorkerGeolocation : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {               

                ServiceGeolocation serviceGeolocation = new ServiceGeolocation();
                string resultjson = serviceGeolocation.GetGeolocalization();

                Console.WriteLine(resultjson);            

                FileLog.WriteLog(resultjson);

                await Task.Delay(3000, stoppingToken);
            }
        }

    }
}
