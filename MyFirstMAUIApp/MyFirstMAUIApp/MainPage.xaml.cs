namespace MyFirstMAUIApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        static string THE_ALPHABET = "abcdefghijklmnopqrstuvwxyz";

        public MainPage()
        {
            InitializeComponent();
        }

        public void OnButtonClicked(object sender, EventArgs e)
        {
            //Change the characters in the result to lowercase
            string resultTextLowercase = nameEntry.Text.ToLower();

            //Name is valid by default
            bool isValidName = true;
            
            foreach (char character in resultTextLowercase)
            {
                //Check if the character is valid
                if (!THE_ALPHABET.Contains(character))
                {
                    //character is not valid; name is not valid
                    isValidName = false;
                    break;
                }
            }

            if (isValidName)
            {
                //Display result as normal
                resultLabel.Text = "Hello, " + nameEntry.Text;
            }
            else
            {
                //Tell the user their name is invalid
                resultLabel.Text = "That is not a valid name";
            }
        }

        public void OnButtonClearClicked(object sender, EventArgs e)
        {
            //Clear the name entry & result label
            nameEntry.Text = string.Empty;
            resultLabel.Text = string.Empty;
        }
    }
}
