namespace MauiProfileApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnShowProfileClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameEntry.Text))
            {
                resultLabel.Text = "You need to enter your name first";
                return;
            }

            string message = $"Hell {nameEntry.Text}";
            if (showMessageSwitch.IsToggled)
            {
                message += $"/nMessage: {messageEntry.Text}";
            }

            resultLabel.Text = message;
            resultLabel.FontSize = fontSlider.Value;
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
