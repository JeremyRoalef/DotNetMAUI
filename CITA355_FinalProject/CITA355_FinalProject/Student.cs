namespace CITA355_FinalProject
{
    internal class Student
    {
        public int studentID {  get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password {  get; set; }
        public string email { get; set; }

        //Parameterless constructor is needed for JSON deserialization
        //Just remember that...
        public Student()
        {

        }

        public Student(
            string firstName, 
            string lastName, 
            string password, 
            string email
            ) : this(-1, firstName, lastName, password, email)
        {

        }

        public Student(
            int studentID,
            string firstName,
            string lastName,
            string password,
            string email
            )
        {
            this.studentID = studentID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
            this.email = email;
        }

    }
}
