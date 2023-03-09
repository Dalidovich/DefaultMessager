namespace DefaultMessager.DAL.BackblazeS3.ClientProvider
{
    public interface IBackblazeClientProvider
    {
        public Task<BackblazeS3Client> GetClient();
    }
}
