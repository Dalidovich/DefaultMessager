namespace DefaultMessager.DAL.BackblazeS3
{
    public class BackblazeClientOptions
    {
        public const string NameSettings = "BackblazeClientOptions";
        public string AccsesKey { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;

        public override string ToString()
        {
            return string.Format("AccsesKey - {0}\nSecretKey - {1}", AccsesKey, SecretKey);
        }
    }
}
