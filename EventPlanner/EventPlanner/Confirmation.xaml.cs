using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner
{
    public partial class Confirmation : ContentPage, IQueryAttributable
    {
        EventData? selectedEvent = null;
        string? userName = string.Empty;
        string? userEmail = string.Empty;
        string? userMNumber = string.Empty;

        public Confirmation()
        {
            InitializeComponent();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            //Try to receive & store the event data
            int eventID = -1;
            if (query.ContainsKey("ID"))
            {
                int.TryParse(query["ID"].ToString(), out eventID);
            }
            if (EventData.EVENTS.ContainsKey(eventID))
            {
                selectedEvent = EventData.EVENTS[eventID];
            }

            //Try to receive & store the user's information
            if (query.ContainsKey("UserName") && query.ContainsKey("UserEmail") && query.ContainsKey("UserMNumber"))
            {
                userName = query["UserName"].ToString();
                userEmail = query["UserEmail"].ToString();
                userMNumber = query["UserMNumber"].ToString();
            }

            labelUserMessage.Text = $"Thank you {userName} for registering for the event. " +
                $"You are registering for {selectedEvent?.Name ?? "unknown"}";
            labelEventDetails.Text = $"{selectedEvent?.Name ?? "Unknown"}" +
                $"\nLocation: {selectedEvent?.Location ?? "Unknown"}" +
                $"\nStart Time: {selectedEvent?.Date.ToString() ?? "Unknown"}";
            labelUserDetails.Text = $"User Name: {userName}" +
                $"\nUser Email: {userEmail}" +
                $"\nUser M#: {userMNumber}";
        }



        async void OnButtonBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(Registration)}",
                new Dictionary<string, object>
                {
                    {"ID", selectedEvent?.ID ?? -1 }
                }
                );
        }

        async void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            //TODO: add user to event's registration details

            await Shell.Current.GoToAsync($"{nameof(RegistrationConfirmation)}",
                new Dictionary<string, object>
                {
                    {"ID", selectedEvent?.ID ?? -1},
                    {"UserName", userName ?? "[missing user name]"},
                    {"UserEmail", userEmail ?? "[missing user email]"},
                    {"UserMNumber", userMNumber ?? "[missing user M#]"}
                }
                );
        }
    }
}
