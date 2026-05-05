namespace CITA355_FinalProject
{
    public partial class CreateAccountPage : ContentPage
    {
        public CreateAccountPage()
        {
            InitializeComponent();
        }

        async void OnHomeClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
        }

        async void OnLoginClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        async void OnCreateAccountClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CreateAccountPage));
        }

        async void OnSearchDatabaseClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(SearchDatabasePage));
        }
    }
}
