namespace CITA355_FinalProject
{
    internal class APIResponse
    {
        public bool Success {  get; set; }
        public Student Student { get; set; }
        public string Message { get; set; }

        //Parameterless constructor needed for JSON deserialization
        //Just remember that...
        public APIResponse()
        {

        }

        public APIResponse(bool success, Student student, string message)
        {
            this.Success = success;
            this.Student = student;
            this.Message = message;
        }
    }
}
