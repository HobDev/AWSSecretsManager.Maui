using Amazon.SecretsManager.Model;
using Amazon.SecretsManager;
using Amazon;
using Amazon.Runtime;


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
          string secret1=await  GetSecretFromAWS();
           
            string secret2 = "Secret 2";
            string secret3 = "Secret 3";

            Label1.Text = $"Secret1:  {secret1}";
            Label2.Text = $"Secret2:  {secret2}";
            Label3.Text = $"Secret3:  {secret3}";

        }

         private async Task<string> GetSecretFromAWS()
        {
            /*    *	Use this code snippet in your app.
    *	If you need more information about configurations or implementing the sample code, visit the AWS docs:
    *	https://aws.amazon.com/developer/language/net/getting-started
    */
            string secretName = "prod/DomeMobile/MongoDBAppId";
            string region = "ca-central-1";

            AWSCredentials credentials = new BasicAWSCredentials( Secrets.AccessKey, Secrets.SecretKey);
            IAmazonSecretsManager client = new AmazonSecretsManagerClient(credentials,RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
            };

            GetSecretValueResponse response;

            try
            {
                response = await client.GetSecretValueAsync(request);
            }
            catch (Exception ex)
            {
                // For a list of the exceptions thrown, see
                // https://docs.aws.amazon.com/secretsmanager/latest/apireference/API_GetSecretValue.html
                throw ex;
            }

            return response.SecretString;
        }
    }
}
