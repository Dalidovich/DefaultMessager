using Amazon.S3;
using Amazon.S3.Model;

namespace DefaultMessager.DAL.SettingsAWSClient
{
    public class AWSS3Client
    {
        private readonly IAmazonS3 _s3Client;

        public AWSS3Client(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }
        public async Task UploadObjectFromStreamAsync(string bucketName,string objectName,MemoryStream stream)
        {
            try
            {
                var putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = objectName,
                    InputStream = stream
                };
                await _s3Client.PutObjectAsync(putRequest);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        public async Task<MemoryStream> GetObject(string bucketName, string objectName)
        {
            try
            {
                var getRequest = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = objectName,
                };
                var s3Object = await _s3Client.GetObjectAsync(getRequest);
                MemoryStream resultStream = new MemoryStream();
                await s3Object.ResponseStream.CopyToAsync(resultStream);
                return resultStream;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw new Exception();
            }
        }
        public async Task CopyBucketToBucket(string soursBucketName,string destBucketName
            , string sourseobjectName)
        {
            try
            {
                await _s3Client.CopyObjectAsync(soursBucketName, sourseobjectName, destBucketName, sourseobjectName);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw new Exception();
            }
        }
    }
}
