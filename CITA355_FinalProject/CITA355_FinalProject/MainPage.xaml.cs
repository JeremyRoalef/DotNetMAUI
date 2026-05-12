namespace CITA355_FinalProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            InitializePage();
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

        async void OnLogoutClicked(object sender, EventArgs e)
        {
            SessionData.Clear();

            await DisplayAlert("Logout Successful", "You have logged out of your account", "OK");

            InitializePage();
        }

        async void OnButtonTakeQuizClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ExamPage));
        }

        private void InitializePage()
        {
            if (SessionData.ActiveStudent == null)
            {
                labelGreetUser.IsVisible = false;
                labelGreetUser.Text = $"";

                buttonTakeQuiz.IsVisible = false;
                buttonLogout.IsVisible = false;
                buttonLogin.IsVisible = true;
                buttonCreateAccount.IsVisible = true;
            }
            else
            {
                labelGreetUser.IsVisible = true;
                labelGreetUser.Text = $"Welcome, {SessionData.ActiveStudent.firstName} {SessionData.ActiveStudent.lastName}";

                buttonTakeQuiz.IsVisible = true;
                buttonLogout.IsVisible = true;
                buttonLogin.IsVisible = false;
                buttonCreateAccount.IsVisible = false;
            }
        }
    }
}
