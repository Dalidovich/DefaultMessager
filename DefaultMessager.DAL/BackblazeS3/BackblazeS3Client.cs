using Bytewizer.Backblaze.Client;
using Bytewizer.Backblaze.Models;
using DefaultMessager.Domain.Enums;

namespace DefaultMessager.DAL.SettingsAWSClient
{
    public class BackblazeS3Client
    {
        private readonly IStorageClient _s3Client;

        public BackblazeS3Client(BackblazeClient s3Client)
        {
            _s3Client = s3Client;
        }
        public async Task<string> UploadObjectFromStreamAsync(string bucketName, string objectName, Stream stream)
        {
            var response=await _s3Client.UploadAsync(await GetIdWithBucketName(bucketName), objectName, stream);
            return response.Response.FileId;
        }
        public async Task DownloadObjectAsync(string bucketName, string objectName, string pathToNewFile)
        {
            FileStream downloadFileStream = new(pathToNewFile + objectName, FileMode.OpenOrCreate);
            await _s3Client.DownloadAsync(await GetIdWithBucketName(bucketName), objectName, downloadFileStream);
        }
        public async Task<bool> DeleteObjectAsync(string bucketName, string objectName)
        {
            try
            {
                ListFileNamesRequest fileNamesRequest = new(await GetIdWithBucketName(bucketName));
                var deleteFile = await _s3Client.Files.FirstAsync(fileNamesRequest, x => x.FileName == objectName);
                var reusltResponceDelete = await _s3Client.Files.DeleteAsync(deleteFile.FileId, deleteFile.FileName);
                return reusltResponceDelete.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private async Task<string> GetIdWithBucketName(string bucketName)
        {
            return (await _s3Client.Buckets.FindByNameAsync(bucketName)).BucketId;
        }
        public async Task<string> GetFileLink(string bucketName, string objectName)
        {
            ListFileNamesRequest fileNamesRequest = new(await GetIdWithBucketName(bucketName));
            var file = await _s3Client.Files.FirstAsync(fileNamesRequest, x => x.FileName == objectName);
            return GetFileLink(file.FileId);
        }
        public string GetFileLink(string fileId)
        {
            return StandartConst.DounloadUrlApi + fileId;
        }
    }
}
