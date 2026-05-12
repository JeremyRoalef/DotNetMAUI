namespace CITA355_FinalProject
{
    internal struct SearchFilters
    {
        public enum SearchFunc
        {
            StudentOnly,
            QuizOnly,
            StudentAndQuiz
        }

        public int studentID;
        public string email;
        public string firstName;
        public string lastName;
        public DateTime examDate;
        public SearchFunc searchFunctionality;

        public SearchFilters(
            int studentID, 
            string email, 
            string firstName, 
            string lastName,
            DateTime examDate, 
            SearchFunc searchFunctionality)
        {
            this.studentID = studentID;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.examDate = examDate;
            this.searchFunctionality = searchFunctionality;
        }
    }
}
