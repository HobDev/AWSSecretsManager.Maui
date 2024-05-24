namespace AWSSecretsManager.Maui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object? sender, EventArgs e)
        {
            string secret1 = "Secret 1";
            string secret2 = "Secret 2";
            string secret3 = "Secret 3";

            Label1.Text = $"Secret1:  {secret1}";
            Label2.Text = $"Secret2:  {secret2}";
            Label3.Text = $"Secret3:  {secret3}";
        }

       
    }

}
