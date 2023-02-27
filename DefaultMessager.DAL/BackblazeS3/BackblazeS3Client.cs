using Bytewizer.Backblaze.Client;
using Bytewizer.Backblaze.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DefaultMessager.DAL.SettingsAWSClient
{
    public class BackblazeS3Client
    {
        private readonly IStorageClient _s3Client;

        public BackblazeS3Client(BackblazeClient s3Client)
        {
            _s3Client = s3Client;
        }
        public async Task UploadObjectFromStreamAsync(string bucketId, string objectName, Stream stream)
        {
            await _s3Client.UploadAsync(bucketId, objectName, stream);
        }
        public async Task DownloadObjectAsync(string bucketId, string objectName, string pathToNewFile)
        {
            FileStream downloadFileStream = new(pathToNewFile + objectName, FileMode.OpenOrCreate);
            await _s3Client.DownloadAsync(bucketId, objectName, downloadFileStream);
        }
        public async Task<bool> DeleteObjectAsync(string bucketId, string objectName) // стоит подумать
        {
            ListFileNamesRequest fileNamesRequest = new(bucketId);
            var deleteFile = await _s3Client.Files.FirstAsync(fileNamesRequest, x => x.FileName == objectName);
            var reusltResponceDelete = await _s3Client.Files.DeleteAsync(deleteFile.FileId, deleteFile.FileName);
            return reusltResponceDelete.IsSuccessStatusCode;
        }
        public async Task<string> GetIdWithBucketName(string bucketName)
        {
            return (await _s3Client.Buckets.FindByNameAsync(bucketName)).BucketId;
        }
        public async Task<string> GetFileLink(string bucketId, string objectName)
        {
            ListFileNamesRequest fileNamesRequest = new(bucketId);
            var a = (await _s3Client.Buckets.FindByIdAsync(bucketId));
            var file = await _s3Client.Files.FirstAsync(fileNamesRequest, x => x.FileName == objectName);

            HttpClient client = new HttpClient();


            Console.WriteLine(file.ContentSha1);
            return null;
        }
    }
}
