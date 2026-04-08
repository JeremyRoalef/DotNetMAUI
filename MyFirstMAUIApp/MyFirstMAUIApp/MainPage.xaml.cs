namespace MyFirstMAUIApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        static string THE_ALPHABET = "abcdefghijklmnopqrstuvwxyz";

        public MainPage()
        {
            InitializeComponent();

            //Initialize UI behaviour
            nameEntry.TextChanged += OnNameChanged;
            greetButton.IsEnabled = false;
            pageTransition.IsVisible = false;
        }

        private void OnNameChanged(object? sender, TextChangedEventArgs e)
        {
            //Check if the new text is valid for a name
            if (!IsValidName(e.NewTextValue))
            {
                //New name isn't valid; added character isn't supported. Set name to old name
                nameEntry.Text = e.OldTextValue;
                return;
            }

            //new name was valid. Set the name to the new name text
            nameEntry.Text = e.NewTextValue;

            //If the passed name isn't empty, then they may be greeted
            greetButton.IsEnabled = !string.IsNullOrWhiteSpace(e.NewTextValue);
        }

        public void OnButtonClicked(object sender, EventArgs e)
        {
            //Check if the name input is valid
            bool isValidName = IsValidName(nameEntry.Text);


            if (isValidName)
            {
                //Display result as normal
                resultLabel.Text = "Hello, " + nameEntry.Text;
                pageTransition.IsVisible = true;
            }
            else
            {
                //Tell the user their name is invalid
                resultLabel.Text = "That is not a valid name";
            }
        }

        private bool IsValidName(string name)
        {
            //Change the characters in the result to lowercase
            string nameLowercase = name.ToLower();

            //Name is valid by default
            bool isValidEntry = true;

            foreach (char character in nameLowercase)
            {
                //Check if the character is valid
                if (!THE_ALPHABET.Contains(character))
                {
                    //character is not valid; name is not valid
                    isValidEntry = false;
                    break;
                }
            }

            return isValidEntry;
        }

        public void OnButtonClearClicked(object sender, EventArgs e)
        {
            //Clear the name entry & result label
            nameEntry.Text = string.Empty;
            resultLabel.Text = string.Empty;
        }

        public async void OnButtonPageTransitionClickedAsync(object? sender, EventArgs e)
        {
            //Begin the page transition to the screensaver page
            await Shell.Current.GoToAsync(nameof(ScreenSaver));
        }
    }
}
