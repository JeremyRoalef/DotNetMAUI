using MauiAppDB1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiAppDB1.Services
{
    public class StudentAPI : ContentPage
    {
        public static async Task<List<Student>> GetStudents()
        {
            //The URL to the web page
            string url = "http://localhost/CITA_355/MAUIDB/getStudents.php";

            //Create a new HTTP client to connect to the web page
            HttpClient client = new HttpClient();

            //Get the echoed JSON string from the page
            string response = await client.GetStringAsync(url);

            //Deserialize the JSON string
            List<Student>? students = JsonSerializer.Deserialize<List<Student>>(response);

            //Return the list
            return students ?? new List<Student>();
        }

        public static async Task<HttpResponseMessage> AddStudent(Student student)
        {
            //The URL to the web page
            string url = "http://localhost/CITA_355/MAUIDB/addStudent.php";

            //Create the HTTP client
            HttpClient httpClient = new HttpClient();

            Dictionary<string, string> studentData = new Dictionary<string, string>()
            {
                {"ID", student.id! },
                {"Name", student.name! },
                {"Dept_Name", student.dept_name! },
                {"GPA", student.gpa! },
                {"email", student.email! }
            };

            FormUrlEncodedContent content = new FormUrlEncodedContent(studentData);
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            return response;
        }

        public static async Task<HttpResponseMessage> UpdateStudent(Student student)
        {
            string url = "http://localhost/CITA_355/MAUIDB/updateStudent.php";

            //Create the client
            HttpClient httpClient = new HttpClient();

            Dictionary<string, string> studentData = new Dictionary<string, string>()
            {
                {"ID", student.id! },
                {"Name", student.name! },
                {"Dept_Name", student.dept_name! },
                {"GPA", student.gpa! },
                {"email", student.email! }
            };

            FormUrlEncodedContent content = new FormUrlEncodedContent(studentData);
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            return response;
        }
    }
}
