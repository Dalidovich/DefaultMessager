using Amazon.S3;

namespace DefaultMessager.DAL.SettingsAWSClient
{
    public class AWSS3Client
    {
        private readonly IAmazonS3 _s3Client;

        public AWSS3Client(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }
    }
}
