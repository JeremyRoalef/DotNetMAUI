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

            if (SessionData.ActiveStudent != null)
            {
                labelGreetUser.IsVisible = true;
                labelGreetUser.Text = $"Welcome, {SessionData.ActiveStudent.firstName} {SessionData.ActiveStudent.lastName}";

                buttonTakeQuiz.IsVisible = true;
            }
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

        async void OnButtonTakeQuizClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ExamPage));
        }
    }
}
