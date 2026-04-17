using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner
{
    public partial class RegistrationConfirmation : ContentPage, IQueryAttributable
    {
        EventData? selectedEvent = null;
        string? userName = string.Empty;
        string? userEmail = string.Empty;
        string? userMNumber = string.Empty;

        public RegistrationConfirmation()
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

            labelConfirmationMessage.Text = $"Thank you {userName ?? "[Missing User Name]"}. " +
                $"You have successfully regisered for the event, {selectedEvent?.Name ?? "[Unknown]"}";
        }

        async void OnButtonReturnToMainMenuClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"///{nameof(EventSelection)}");
        }
    }
}
