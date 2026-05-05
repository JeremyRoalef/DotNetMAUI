using System.Text.Json;

namespace CITA355_FinalProject
{
    internal static class ExamAPI
    {
        public static async Task<Message> AddStudent(Student student)
        {
            //URL to add new account
            string url = "http://localhost/CITA_355/Project2/processNewAccountAPI.php";

            //Create the HTTP Client
            HttpClient httpClient = new HttpClient();

            //Dictionary of data to pass to the web page
            Dictionary<string, string> accountData = new Dictionary<string, string>()
            {
                {"firstName", student.firstName },
                {"lastName", student.lastName },
                {"email" , student.email },
                {"password", student.password}
            };

            //Send the information to the web page
            FormUrlEncodedContent content = new FormUrlEncodedContent(accountData);
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            string responseAsString = await response.Content.ReadAsStringAsync();

            Message? message = JsonSerializer.Deserialize<Message>(responseAsString);

            //Return the response
            return message;
        }
    }
}
