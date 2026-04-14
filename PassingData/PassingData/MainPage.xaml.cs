namespace PassingData
{
    public partial class MainPage : ContentPage
    {
        static string THE_ALPHABET = "abcdefghijklmnopqrstuvwxyz";

        public MainPage()
        {
            InitializeComponent();
            invalidNameLabel.IsVisible = false;
            invalidAgeLabel.IsVisible = false;
            Shell.SetTabBarIsVisible(this, false);

            nameEntry.TextChanged += HandleNameChanged;
            ageEntry.TextChanged += HandleAgeChanged;
        }

        private void HandleAgeChanged(object? sender, TextChangedEventArgs e)
        {
            UpdateTabBarVisibility();
        }

        private void HandleNameChanged(object? sender, TextChangedEventArgs e)
        {
            UpdateTabBarVisibility();
        }

        void UpdateTabBarVisibility()
        {
            Shell.SetTabBarIsVisible(this, IsValidAge() && IsValidName());
        }

        private bool IsValidAge()
        {
            if (ageEntry.Text == null)
            {
                return false;
            }

            //If no age given, then age is not valid
            if (ageEntry.Text.Length == 0)
            {
                return false;
            }

            int userAge = 0;

            //If you can't get the age as a number, then it's not valid
            if (!int.TryParse(ageEntry.Text, out userAge))
            {
                return false;
            }

            //If age is 0, negative, or very old, then it's not valid
            if (userAge <= 0 || userAge > 150)
            {
                return false;
            }

            //Age is valid
            return true;
        }

        private bool IsValidName()
        {
            //If no name entry, then it's not a valid name
            if (nameEntry.Text == null)
            {
                //No name
                return false;
            }
            
            if (nameEntry.Text.Length == 0)
            {
                //no name given
                return false;
            }

            //Check for invalid characters
            string nameInputToLower = nameEntry.Text.ToLower();

            foreach (char c in nameInputToLower)
            {
                //If the character is not in the alphabet, then it's not a valid name
                if (!THE_ALPHABET.Contains(c))
                {
                    return false;
                }
            }

            //Name is valid
            return true;
        }

        async void OnGoClicked(object? sender, EventArgs e)
        {
            //If age and name are valid, then transition to next page
            bool isValidName = IsValidName();
            bool isValidAge = IsValidAge();

            if (isValidAge && isValidName)
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
                return;
            }

            //Handle age being invalid
            invalidAgeLabel.IsVisible = !isValidAge;

            //Handle name being invalid
            invalidNameLabel.IsVisible = !isValidName;
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
