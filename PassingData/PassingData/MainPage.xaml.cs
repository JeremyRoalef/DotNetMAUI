namespace PassingData
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        async void OnGoClicked(object? sender, EventArgs e)
        {
            string name = nameEntry.Text ?? "";
            int age = -1;
            int.TryParse(ageEntry.Text, out age);

            await Shell.Current.GoToAsync(
                nameof(SecondPage),
                new Dictionary<string, object>
                {
                    { "UserName", name },
                    {"UserAge", age }
                }
                );
        }

        async void OnGoToThirdPageClicked(object? sender, EventArgs e)
        {
            //try to get the user's email
            string userEmail = emailEntry.Text ?? string.Empty;

            await Shell.Current.GoToAsync(
                nameof(ThirdPage),
                new Dictionary<string, object>
                {
                    {"UserEmail", userEmail}
                }
                );
        }
    }
}
