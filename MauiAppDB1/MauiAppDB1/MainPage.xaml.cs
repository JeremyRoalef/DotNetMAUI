using MauiAppDB1.Models;
using MauiAppDB1.Services;

namespace MauiAppDB1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        async void LoadStudents(object sedner, EventArgs e)
        {
            List<Student> students = await StudentAPI.GetStudents();
            studentList.ItemsSource = students;
        }

        async void AddStudent(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddStudent));
        }

        async void OnUpdateStudent(object sender, EventArgs e)
        {
            Button button = sender as Button;

            //Get the student associated with this event call
            Student student = (Student)button.CommandParameter;

            await Shell.Current.GoToAsync(nameof(UpdateStudent), new Dictionary<string, object>
            {
                {"student", student }
            });
        }
    }
}
