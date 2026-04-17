using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner
{
    public partial class Confirmation : ContentPage
    {
        EventData? selectedEvent = null;
        UserData? userData = null;

        public Confirmation()
        {
            InitializeComponent();

            selectedEvent = SessionData.SelectedEvent;
            userData = SessionData.UserData;

            labelUserMessage.Text = $"Thank you {userData?.UserName ?? "[Unknown Name]"} for registering for the event. " +
             $"You are registering for {selectedEvent?.Name ?? "unknown"}";
            labelEventDetails.Text = $"{selectedEvent?.Name ?? "Unknown"}" +
                $"\nLocation: {selectedEvent?.Location ?? "Unknown"}" +
                $"\nStart Time: {selectedEvent?.Date.ToString() ?? "Unknown"}";
            labelUserDetails.Text = $"User Name: {userData?.UserName ?? "[Unknown Name]"}" +
                $"\nUser Email: {userData?.UserEmail ?? "[Unknown Email]"}" +
                $"\nUser M#: {userData?.UserMNumber ?? "[Unknown M#]"}";
        }

        async void OnButtonBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(Registration)}",
                new Dictionary<string, object>
                {
                    {nameof(EventData.ID), selectedEvent?.ID ?? -1 },
                    {nameof(UserData), userData! } //"!" tells Intellisense that IDGAF if it's null & it cannot be null
                }
                );
        }

        async void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            if (selectedEvent == null) return;
            if (userData == null) return;
            //Get the corresponding list for users registered for the event
            
            EventData.AddUserToEvent(selectedEvent.ID, userData);
            await Shell.Current.GoToAsync($"{nameof(RegistrationConfirmation)}");
        }
    }
}
