namespace DefaultMessager.DAL.SettingsAWSClient
{
    public class AWSClientOptions
    {
        public const string NameSettings = "AWSClientOptions";
        public string AccsesKey { get; set; } = String.Empty;
        public string SecretKey { get; set; } = String.Empty;
        public string ServiceURL { get; set; } = String.Empty;

        public override string ToString()
        {
            return string.Format("AccsesKey - {0}\nSecretKey - {1}\nServiceURL - {2}", AccsesKey.ToString(),SecretKey,ServiceURL);
        }
    }
}
