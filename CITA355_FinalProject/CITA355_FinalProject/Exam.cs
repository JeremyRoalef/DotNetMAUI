namespace CITA355_FinalProject
{
    internal class Exam
    {
        public string Q1Selection {  get; private set; }
        public string[] Q2Selection { get; private set; }
        public string Q3Selection { get; private set; }
        public string Q4Selection { get; private set; }
        public string Q5Selection { get; private set; }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public DateTime Date {  get; private set; }

        public Exam(
            string q1Selection, 
            string[] q2Selection, 
            string q3Selection, 
            string q4Selection, 
            string q5Selection,
            DateTime startTime,
            DateTime endTime,
            DateTime date
            )
        {
            this.Q1Selection = q1Selection;
            this.Q2Selection = q2Selection;
            this.Q3Selection = q3Selection;
            this.Q4Selection = q4Selection;
            this.Q5Selection = q5Selection;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Date = date;
        }
    }
}
