using MauiAppDB1.Models;
using MauiAppDB1.Services;

namespace MauiAppDB1
{
    public partial class MainPage : ContentPage
    {
        StudentServices studentServices = new StudentServices();
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        async void LoadStudents(object sedner, EventArgs e)
        {
            List<Student> students = await studentServices.GetStudents();
            studentList.ItemsSource = students;
        }
    }
}
