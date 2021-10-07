namespace CarRentalSystem.Identity
{
    using CarRentalSystem.Infrastructure;
    using CarRentalSystem.Services;
    using Data;
    using Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services.Identity;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .Configure<IdentitySettings>(
                    this.Configuration.GetSection(nameof(IdentitySettings)),
                    config => config.BindNonPublicProperties = true)
                .AddWebService<IdentityDbContext>(
                    this.Configuration,
                    messagingHealthChecks: false)
                .AddUserStorage()
                .AddTransient<IDataSeeder, IdentityDataSeeder>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<ITokenGeneratorService, TokenGeneratorService>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
