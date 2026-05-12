using System.Collections.ObjectModel;
using System.Net.Mail;

namespace CITA355_FinalProject
{
    public partial class SearchDatabasePage : ContentPage
    {
        public ObservableCollection<SearchResult> Results { get; set; } = new();

        public SearchDatabasePage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        bool IsValidFirstName()
        {
            if (string.IsNullOrWhiteSpace(entryFirstName.Text))
            {
                return false;
            }

            return true;
        }

        bool IsValidLastName()
        {
            if (string.IsNullOrWhiteSpace(entryLastName.Text))
            {
                return false;
            }

            return true;
        }

        bool IsValidEmail()
        {
            if (string.IsNullOrWhiteSpace(entryEmail.Text))
            {
                return false;
            }

            //Validate the email for proper format
            if (!MailAddress.TryCreate(entryEmail.Text, out _))
            {
                //Could not create a mail address from the given email string
                return false;
            }

            return true;
        }

        bool IsValidStudentID()
        {
            return int.TryParse(entryStudentID.Text, out _);
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

        async void OnSearch(object sender, EventArgs e)
        {
            SearchFilters.SearchFunc searchFunc = SearchFilters.SearchFunc.StudentOnly;

            switch (pickerSearchFunc.SelectedItem)
            {
                case "Students":
                    searchFunc = SearchFilters.SearchFunc.StudentOnly;
                    break;
                case "Quizzes":
                    searchFunc = SearchFilters.SearchFunc.QuizOnly;
                    break;
                case "Students and Quizzes":
                    searchFunc = SearchFilters.SearchFunc.StudentAndQuiz;
                    break;
            }

            //Create the search filter
            SearchFilters filters = new SearchFilters(
                    IsValidStudentID() ? int.Parse(entryStudentID.Text) : -1,
                    IsValidEmail() ? entryEmail.Text : string.Empty,
                    IsValidFirstName() ? entryFirstName.Text : string.Empty,
                    IsValidLastName() ? entryLastName.Text : string.Empty,
                    checkboxUseDate.IsChecked ? datePicker.Date : DateTime.MinValue,
                    searchFunc
                );

            try
            {
                //Get the search results
                APISearchResponse searchResponse = await ExamAPI.SearchDatabase(filters);

                //Store the results in the List of dictionaries
                Results.Clear();

                foreach (SearchResult result in searchResponse.Results)
                {
                    Results.Add(result);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Search Failed", ex.Message, "OK");
            }
        }
    }
}
