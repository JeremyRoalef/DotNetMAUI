namespace CITA355_FinalProject
{
    public partial class ExamPage : ContentPage
    {
        DateTime startTime;

        public ExamPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Get the exam starting time
            startTime = DateTime.Now;
        }

        async void OnSubmitExam(object sender, EventArgs e)
        {
            //Validate Exam Completion
            bool q1IsAnswered = RadioButtonGroup.GetSelectedValue(Question1) != null;
            bool q2IsAnswered = (checkboxPython.IsChecked || checkboxJavascript.IsChecked || checkboxPHP.IsChecked);
            bool q3IsAnswered = RadioButtonGroup.GetSelectedValue(Question3) != null;
            bool q4IsAnswered = pickerQuestion4.SelectedItem != null;
            bool q5IsAnswered = RadioButtonGroup.GetSelectedValue(Question5) != null;

            if (!q1IsAnswered || !q2IsAnswered || !q3IsAnswered || !q4IsAnswered || !q5IsAnswered)
            {
                await DisplayAlert("Exam Not Finished", "One or more questions have not been answered", "OK");
                return;
            }

            //Exam has been validated

            //Process question 2 checkboxes for selections
            List<string> selectedAnswersForQuestion2 = new List<string>();
            if (checkboxPython.IsChecked)
            {
                selectedAnswersForQuestion2.Add("python");
            }
            if (checkboxJavascript.IsChecked)
            {
                selectedAnswersForQuestion2.Add("javascript");
            }
            if (checkboxPHP.IsChecked)
            {
                selectedAnswersForQuestion2.Add("php");
            }

            //Convert the list to an array
            string[] question2AnswerArray = selectedAnswersForQuestion2.ToArray();

            //Get the time taken on the exam
            DateTime endTime = DateTime.Now;
            

            //Craete the exam object
            Exam exam = new Exam(
                RadioButtonGroup.GetSelectedValue(Question1).ToString()!,
                question2AnswerArray,
                RadioButtonGroup.GetSelectedValue(Question3).ToString()!,
                pickerQuestion4.SelectedItem!.ToString()!,
                RadioButtonGroup.GetSelectedValue(Question5).ToString()!,
                startTime,
                endTime,
                endTime.Date
                );

            try
            {
                //Submit the exam
                APIExamResponse response = await ExamAPI.SubmitExam(SessionData.ActiveStudent!, exam);

                if (response.Success)
                {
                    await DisplayAlert("Test Submitted", $"{response.Message}\nYour final score is {response.Score.ToString("F2")}%", "OK");

                    //Return to home page
                    await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
                }
                else
                {
                    await DisplayAlert("Submission Failed", response.Message, "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Submission Failed", ex.Message, "OK");
            }

        }
    }
}
