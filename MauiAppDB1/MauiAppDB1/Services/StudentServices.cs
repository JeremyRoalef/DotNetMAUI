using MauiAppDB1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiAppDB1.Services
{
    public class StudentServices
    {
        //The URL to the web page
        string url = "http://localhost/CITA_355/MAUIDB/getStudents.php";

        public async Task<List<Student>> GetStudents()
        {
            //Create a new HTTP client to connect to the web page
            HttpClient client = new HttpClient();

            //Get the echoed JSON string from the page
            string response = await client.GetStringAsync(url);

            //Deserialize the JSON string
            List<Student>? students = JsonSerializer.Deserialize<List<Student>>(response);

            //Return the list
            return students ?? new List<Student>();
        }
    }
}
