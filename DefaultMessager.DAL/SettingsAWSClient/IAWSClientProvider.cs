namespace DefaultMessager.DAL.SettingsAWSClient
{
    public interface IAWSClientProvider
    {
        public AWSS3Client GetClient();
    }
}
