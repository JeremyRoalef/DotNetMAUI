namespace CITA355_FinalProject
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object? sender, EventArgs e)
        {
            //Test adding new student to the db
            Student newStudent = new Student("bill", "bill", "bill", "bill@mor");
            Message message = await ExamAPI.AddStudent(newStudent);
            await DisplayAlert("Response", message.message, "OK");
        }
    }
}
