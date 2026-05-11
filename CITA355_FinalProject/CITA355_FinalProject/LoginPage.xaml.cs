using System.Net.Mail;

namespace CITA355_FinalProject
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
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

        bool IsValidEmail()
        {
            if (string.IsNullOrWhiteSpace(entryEmailOrID.Text))
            {
                return false;
            }

            //Validate the email for proper format
            if (!MailAddress.TryCreate(entryEmailOrID.Text, out _))
            {
                //Could not create a mail address from the given email string
                return false;
            }
            return true;
        }

        bool IsValidPassword()
        {
            if (string.IsNullOrWhiteSpace(entryPassword.Text))
            {
                labelPassword.TextColor = Colors.Red;
                return false;
            }

            labelPassword.TextColor = Colors.White;
            return true;
        }

        async void OnSubmitLogin(object sender, EventArgs e)
        {
            bool isValidPassword = IsValidPassword();
            bool isValidEmail = IsValidEmail();
            int studentID = -1;

            //See if the user is logging in from their student ID
            if (!isValidPassword)
            {
                await DisplayAlert("Invalid Credentials", "Password was not properly submitted", "OK");
                return;
            }

            try
            {
                if (int.TryParse(entryEmailOrID.Text, out studentID) && isValidPassword)
                {
                    //try to get the student via ID
                    APIResponse response = await ExamAPI.Login(studentID, entryPassword.Text);


                    if (response.Success)
                    {
                        await DisplayAlert("Logged In", response.Message, "OK");

                        //Set the current student to the received student
                        SessionData.ActiveStudent = response.Student;

                        //Return to home page
                        await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
                    }
                    else
                    {
                        await DisplayAlert("Failed to login", response.Message, "OK");
                    }
                }
                else if (isValidEmail && isValidPassword)
                {
                    //Try to get the student via email
                    APIResponse response = await ExamAPI.Login(entryEmailOrID.Text, entryPassword.Text);

                    if (response.Success)
                    {
                        await DisplayAlert("Logged In", response.Message, "OK");

                        //Set the current student to the received student
                        SessionData.ActiveStudent = response.Student;

                        //Return to home page
                        await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
                    }
                    else
                    {
                        await DisplayAlert("Failed to login", response.Message, "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
