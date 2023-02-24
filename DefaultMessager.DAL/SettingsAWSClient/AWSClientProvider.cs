using Amazon.Runtime;
using Amazon.S3;
using Microsoft.Extensions.Options;

namespace DefaultMessager.DAL.SettingsAWSClient
{
    public class AWSClientProvider : IAWSClientProvider
    {
        public AWSClientOptions _AWSClientOptions { get; set; }

        public AWSClientProvider(IOptions<AWSClientOptions> AWSClientOptions)
        {
            _AWSClientOptions = AWSClientOptions.Value;
        }
        public AWSS3Client GetClient()
        {
            Console.WriteLine(_AWSClientOptions);

            var config = new AmazonS3Config { ServiceURL = _AWSClientOptions.ServiceURL };

            var credentials = new BasicAWSCredentials(_AWSClientOptions.AccsesKey, _AWSClientOptions.SecretKey);

            IAmazonS3 _s3Client = new AmazonS3Client(credentials, config);

            return new AWSS3Client(_s3Client);
        }
    }
}
