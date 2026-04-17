using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        static Dictionary<int, List<UserData>> REGISTERED_EVENT_USERS = new Dictionary<int, List<UserData>>()
        {
            {1, new List<UserData>() },
            {2, new List<UserData>() },
            {3, new List<UserData>() }
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

        public static void AddUserToEvent(int eventID, UserData userData)
        {
            if (REGISTERED_EVENT_USERS.ContainsKey(eventID))
            {
                REGISTERED_EVENT_USERS[eventID].Add(userData);
                WriteToJSON();
            }
        }

        static void WriteToJSON()
        {
            //Serialize the registered event user dictionary
            string jsonString = JsonSerializer.Serialize(REGISTERED_EVENT_USERS);

            //Create the file path where this data will be stored
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "registeredEventUsers.json");

            //Write the file
            File.WriteAllText(filePath, jsonString);
        }

        public static void Initialize()
        {
            //Get the file path for the registered event users
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "registeredEventUsers.json");

            //Try to initialize the registered event user dictionary from the JSON file
            if (File.Exists(filePath))
            {
                //Get the string content from the file
                string jsonString = File.ReadAllText(filePath);

                //Deserialize the JSON content to the registered event users dictionary
                REGISTERED_EVENT_USERS = JsonSerializer.Deserialize<Dictionary<int, List<UserData>>>(jsonString)!;
            }
        }
    }
}
