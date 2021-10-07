namespace RESTClient
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.Json;
    using RESTCommon;

    public class Program
    {
        public static async Task Main()
        {
            using var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001")
            };

            const string url = "/WeatherForecast";

            // Save weather
            var weather = new WeatherForecast
            {
                Summary = "Hot"
            };

            var jsonBody = JsonSerializer.Serialize(weather);

            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            using var postResponse = await httpClient.PostAsync(url, content);

            if (!postResponse.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("Bad weather");
            }

            // Get weather
            using var getResponse = await httpClient.GetAsync(url);

            var jsonResult = await getResponse.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<WeatherForecast>(jsonResult, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            Console.WriteLine(result.Summary);

            Console.ReadLine();
        }
    }
}
