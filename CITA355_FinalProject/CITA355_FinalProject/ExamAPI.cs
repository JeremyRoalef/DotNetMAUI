using Microsoft.Maui.ApplicationModel.Communication;
using System.Text.Json;

namespace CITA355_FinalProject
{
    internal static class ExamAPI
    {
        public static async Task<APIResponse> AddStudent(Student student)
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

            

            APIResponse? apiResponse = JsonSerializer.Deserialize<APIResponse>(responseAsString);

            //Return the response
            return apiResponse;
        }

        public static async Task<APIResponse> GetStudent(int studentID)
        {
            //URL to add new account
            string url = "http://localhost/CITA_355/Project2/getStudent.php";

            //Create the HTTP Client
            HttpClient httpClient = new HttpClient();

            //Dictionary of data to pass to the web page
            Dictionary<string, string> accountData = new Dictionary<string, string>()
            {
                {"studentID", studentID.ToString()}
            };

            //Send the information to the web page
            FormUrlEncodedContent content = new FormUrlEncodedContent(accountData);
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            string responseAsString = await response.Content.ReadAsStringAsync();

            APIResponse? apiResponse = JsonSerializer.Deserialize<APIResponse>(responseAsString);

            //Return the response
            return apiResponse;
        }

        public static async Task<APIResponse> GetStudent(string email)
        {
            //URL to add new account
            string url = "http://localhost/CITA_355/Project2/getStudentAPI.php";

            //Create the HTTP Client
            HttpClient httpClient = new HttpClient();

            //Dictionary of data to pass to the web page
            Dictionary<string, string> accountData = new Dictionary<string, string>()
            {
                {"studentEmail", email.ToString()}
            };

            //Send the information to the web page
            FormUrlEncodedContent content = new FormUrlEncodedContent(accountData);
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            string responseAsString = await response.Content.ReadAsStringAsync();

            APIResponse? apiResponse = JsonSerializer.Deserialize<APIResponse>(responseAsString);

            //Return the response
            return apiResponse;
        }

        public static async Task<APIResponse> Login(int studentID, string password)
        {
            //URL to login
            string url = "http://localhost/CITA_355/Project2/processLoginAPI.php";

            //Create the HTTP Client
            HttpClient httpClient = new HttpClient();

            //Dictionary of data to pass to the web page
            Dictionary<string, string> loginData = new Dictionary<string, string>()
            {
                {"studentID", studentID.ToString()},
                {"password", password}
            };

            //Send the information to the web page
            FormUrlEncodedContent content = new FormUrlEncodedContent(loginData);
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            string responseAsString = await response.Content.ReadAsStringAsync();

            APIResponse? apiResponse = JsonSerializer.Deserialize<APIResponse>(responseAsString);

            //Return the response
            return apiResponse;
        }

        public static async Task<APIResponse> Login(string studentEmail, string password)
        {
            //URL to login
            string url = "http://localhost/CITA_355/Project2/processLoginAPI.php";

            //Create the HTTP Client
            HttpClient httpClient = new HttpClient();

            //Dictionary of data to pass to the web page
            Dictionary<string, string> loginData = new Dictionary<string, string>()
            {
                {"email", studentEmail},
                {"password", password}
            };

            //Send the information to the web page
            FormUrlEncodedContent content = new FormUrlEncodedContent(loginData);
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            string responseAsString = await response.Content.ReadAsStringAsync();

            APIResponse? apiResponse = JsonSerializer.Deserialize<APIResponse>(responseAsString);

            //Return the response
            return apiResponse;
        }
    }
}
