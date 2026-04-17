using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner
{
    public class SessionData
    {
        public static UserData? UserData { get; private set; }
        public static EventData? SelectedEvent {  get; private set; }
        public static void SetUserData(UserData newUserData) => UserData = newUserData;
        public static void SetSelectedEvent(EventData newEventData) => SelectedEvent = newEventData;
    }
}
