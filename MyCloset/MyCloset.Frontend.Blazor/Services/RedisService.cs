using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Diagnostics;

namespace MyCloset.Frontend.Blazor.Services
{
    public class RedisService : IRedisService
    {
        private readonly IConfiguration _configuration;

        public RedisService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            // Verify configuration exists
            var host = _configuration.GetValue<string>("Redis:Host")
                ?? throw new InvalidOperationException("Redis Host configuration missing");

            Debug.WriteLine($"Using Redis connection settings: Host={host}");
        }

        public void GetData()
        {
            try
            {
                string host = _configuration["Redis:Host"];
                int port = Int32.Parse(_configuration["Redis:Port"]);
                string user = _configuration["Redis:User"];
                string psw = _configuration["Redis:Password"];

                var muxer = ConnectionMultiplexer.Connect(
                new ConfigurationOptions
                {
                    EndPoints = { { host!, port } },
                    User = user,
                    Password = psw,
                    AbortOnConnectFail = false
                }
                );
                var db = muxer.GetDatabase();

                RedisValue result = db.StringGet("obama");
                Debug.WriteLine(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
