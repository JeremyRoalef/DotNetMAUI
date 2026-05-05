namespace CITA355_FinalProject
{
    internal class Student
    {
        public int studentID {  get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string password {  get; private set; }
        public string email { get; private set; }

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
