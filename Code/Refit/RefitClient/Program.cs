namespace RefitClient
{
    using System;
    using System.Threading.Tasks;
    using Refit;
    using RefitCommon;

    public class Program
    {
        public static async Task Main()
        {
            var service = RestService.For<IWeatherForecastService>("https://localhost:5001");

            // Save weather
            var weather = new WeatherForecast
            {
                Summary = "Hot"
            };

            await service.CreateWeatherForecast(weather);

            // Get weather
            var result = await service.GetWeatherForecast();

            Console.WriteLine(result.Summary);

            Console.ReadLine();
        }
    }
}
