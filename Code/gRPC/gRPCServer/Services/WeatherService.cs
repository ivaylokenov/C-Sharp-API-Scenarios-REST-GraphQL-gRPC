namespace gRPCServer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Grpc.Core;

    public class WeatherService : Weather.WeatherBase
    {
        private static readonly List<WeatherForecast> Data = new List<WeatherForecast>
        {
            new WeatherForecast { Summary = "Cold" }
        };

        public override Task<StatusResponse> SaveForecast(WeatherForecast request, ServerCallContext context)
        {
            if (string.IsNullOrEmpty(request.Summary))
            {
                return Task.FromResult(new StatusResponse { Success = false });
            }

            Data.Add(request);

            return Task.FromResult(new StatusResponse { Success = true });
        }

        public override Task<WeatherForecast> GetForecast(Empty request, ServerCallContext context)
            => Task.FromResult(Data.OrderBy(x => Guid.NewGuid()).FirstOrDefault());
    }
}
