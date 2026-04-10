namespace MauiProfileApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            showMessageSwitch.Toggled += OnShowMessageToggled;

            //Initialize profile image visibility
            profileImage.IsVisible = showMessageSwitch.IsToggled;
        }

        private void OnShowMessageToggled(object? sender, ToggledEventArgs e)
        {
            profileImage.IsVisible = showMessageSwitch.IsToggled;
        }

        void OnShowProfileClicked(object sender, EventArgs e)
        {
            //Handle missing input
            string errorMessage = "";

            if (string.IsNullOrEmpty(nameEntry.Text))
            {
                errorMessage += "You need to enter your name first\n";
            }
            if (string.IsNullOrWhiteSpace(messageEntry.Text) || string.IsNullOrEmpty(messageEntry.Text))
            {
                errorMessage += "Please enter a message before continuing.";
            }

            if (!string.IsNullOrEmpty(errorMessage) || !string.IsNullOrWhiteSpace(errorMessage))
            {
                //Invalid input found; display error message
                resultLabel.Text = errorMessage;
                return;
            }

            string greetingOpener = greetingPicker.SelectedItem == null ? 
                greetingPicker.Items.FirstOrDefault().ToString() : greetingPicker.SelectedItem.ToString();

            string message = $"{greetingOpener}, {nameEntry.Text}";
            if (showMessageSwitch.IsToggled)
            {
                message += $"\nMessage: {messageEntry.Text}";
            }

            //Get the current date & display it
            string currentDate = DateTime.Now.ToShortDateString();
            message += $"\n{currentDate}";

            resultLabel.Text = message;
            resultLabel.FontSize = fontSlider.Value;
            resultLabel.TextColor = Colors.Green;
        }

        void OnClearClicked(object sender, EventArgs e)
        {
            nameEntry.Text = string.Empty;
            resultLabel.Text = string.Empty;
            messageEntry.Text = string.Empty;
            fontSlider.Value = 18;
        }
    }
}
