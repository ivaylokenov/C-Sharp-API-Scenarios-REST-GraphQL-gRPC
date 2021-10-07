namespace gRPCClient
{
    using System;
    using System.Threading.Tasks;
    using Grpc.Net.Client;
    using gRPCServer;

    public class Program
    {
        public static async Task Main()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Weather.WeatherClient(channel);

            var weather = new WeatherForecast { Summary = "Hot" };
            var reply = await client.SaveForecastAsync(weather);

            Console.WriteLine(reply.Success);

            var result = await client.GetForecastAsync(new Empty());

            Console.WriteLine(result.Summary);

            Console.ReadKey();
        }
    }
}
