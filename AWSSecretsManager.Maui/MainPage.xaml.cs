using Amazon.SecretsManager.Model;
using Amazon.SecretsManager;
using Amazon;
using Amazon.Runtime;
using Amazon.SecretsManager.Extensions.Caching;


namespace AWSSecretsManager.Maui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private async void  OnLoaded(object? sender, EventArgs e)
        {
            string secretName = Secrets.SecretName;
            string region = Secrets.Region;

            AWSCredentials credentials = new BasicAWSCredentials(Secrets.AccessKey, Secrets.SecretKey);
            IAmazonSecretsManager amazonSecretsManager = new AmazonSecretsManagerClient(credentials, RegionEndpoint.GetBySystemName(region));
            SecretCacheConfiguration cacheConfig = new SecretCacheConfiguration
            {
                // the TTL cache refresh duration to 24 hours
                CacheItemTTL = 86400000
            };

            SecretsManagerCache cache = new SecretsManagerCache(amazonSecretsManager, cacheConfig);

            string response = string.Empty;

            try
            {
                response = await cache.GetSecretString(secretName);

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }

            

            Label1.Text=$"Secret= {response}";  
        }

        
    }
}
