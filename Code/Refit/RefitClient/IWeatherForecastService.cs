namespace RefitClient
{
    using System.Threading.Tasks;
    using Refit;
    using RefitCommon;

    public interface IWeatherForecastService
    {
        [Post("/WeatherForecast")]
        Task CreateWeatherForecast([Body] WeatherForecast forecast);

        [Get("/WeatherForecast")]
        Task<WeatherForecast> GetWeatherForecast();
    }
}
