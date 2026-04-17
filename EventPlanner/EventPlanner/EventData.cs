using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner
{
    public class EventData
    {
        //Hard-Coded events
        public static Dictionary<int, EventData> EVENTS = new Dictionary<int, EventData>()
        {
            {1, new EventData(1, "Book Club", "Morrisville Library", new DateTime(2026, 04, 20)) },
            {2, new EventData(2, "Earth Day", "Student Recreation Center", new DateTime(2026, 04, 22)) },
            {3, new EventData(3, "Applied Learning Student Showcase", "Student Recreation Center", new DateTime(2026, 04, 22)) }
        };

        public int ID { get; private set; }
        public string Name {  get; private set; }
        public string Location {  get; private set; }
        public DateTime Date { get; private set; }

        public EventData(int id, string name, string location, DateTime date)
        {
            ID = id;
            Name = name;
            Location = location;
            Date = date;
        }
    }
}
