using System.Net.Mail;

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

        async void OnSearchDatabaseClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(SearchDatabasePage));
        }

        bool IsValidFirstName()
        {
            if (string.IsNullOrWhiteSpace(entryFirstName.Text))
            {
                labelFirstName.TextColor = Colors.Red;

                return false;
            }

            labelFirstName.TextColor = Colors.White;
            return true;
        }

        bool IsValidLastName()
        {
            if (string.IsNullOrWhiteSpace(entryLastName.Text))
            {
                labelLastName.TextColor = Colors.Red;
                return false;
            }

            labelLastName.TextColor = Colors.White;
            return true;
        }

        bool IsValidEmail()
        {
            if (string.IsNullOrWhiteSpace(entryEmail.Text))
            {
                labelEmail.TextColor = Colors.Red;
                return false;
            }

            //Validate the email for proper format
            if (!MailAddress.TryCreate(entryEmail.Text, out _))
            {
                //Could not create a mail address from the given email string
                labelEmail.TextColor = Colors.Red;
                return false;
            }

            labelEmail.TextColor = Colors.White;
            return true;
        }

        bool IsValidPassword()
        {
            if (string.IsNullOrWhiteSpace(entryPassword.Text) || string.IsNullOrWhiteSpace(entryConfirmPassword.Text))
            {
                labelPassword.TextColor = Colors.Red;
                labelConfirmPassword.TextColor = Colors.Red;
                return false;
            }

            if (entryPassword.Text != entryConfirmPassword.Text)
            {
                labelPassword.TextColor = Colors.Red;
                labelConfirmPassword.TextColor = Colors.Red;
                return false;
            }

            labelPassword.TextColor = Colors.White;
            labelConfirmPassword.TextColor = Colors.White;
            return true;
        }

        async void OnButtonSubmitClicked(object sender, EventArgs e)
        {
            bool isValidFirstName = IsValidFirstName();
            bool isValidLastName = IsValidLastName();
            bool isValidEmail = IsValidEmail();
            bool isValidPassword = IsValidPassword();


            if (!isValidFirstName || !isValidLastName || !isValidEmail || !isValidPassword) return;

            //Craete the student object
            Student student = new Student(
                entryFirstName.Text, 
                entryLastName.Text, 
                entryPassword.Text, 
                entryEmail.Text
                );

            try
            {
                APIResponse addStudentResponse = await ExamAPI.AddStudent(student);
                await DisplayAlert("Submitted", addStudentResponse.Message, "OK");

                //Retrieve the full student information, & set the active student to that student
                APIResponse studentAPIResponse = await ExamAPI.GetStudent(student.email);

                if (studentAPIResponse.Success)
                {
                    //Store the new active user & reload the home page
                    SessionData.ActiveStudent = studentAPIResponse.Student;
                }
                else
                {
                    //There was a problem retrieving the student information
                    await DisplayAlert("Error", studentAPIResponse.Message, "OK");
                }

                //Return to main page
                await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
