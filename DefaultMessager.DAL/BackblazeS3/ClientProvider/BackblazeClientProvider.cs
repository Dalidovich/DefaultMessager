using Bytewizer.Backblaze.Client;
using DefaultMessager.DAL.SettingsAWSClient;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DefaultMessager.DAL.BackblazeS3.ClientProvider
{
    public class BackblazeClientProvider : IBackblazeClientProvider
    {
        public BackblazeClientOptions _AWSClientOptions { get; set; }

        public BackblazeClientProvider(IOptions<BackblazeClientOptions> AWSClientOptions)
        {
            _AWSClientOptions = AWSClientOptions.Value;
        }
        public async Task<BackblazeS3Client> GetClient()
        {
            var options = new ClientOptions();
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter("Bytewizer.Backblaze", LogLevel.Trace);
            });
            var cache = new MemoryCache(new MemoryCacheOptions());

            var Client = new BackblazeClient(options, loggerFactory, cache);

            await Client.ConnectAsync(_AWSClientOptions.AccsesKey, _AWSClientOptions.SecretKey);

            return new BackblazeS3Client(Client);
        }
    }
}
