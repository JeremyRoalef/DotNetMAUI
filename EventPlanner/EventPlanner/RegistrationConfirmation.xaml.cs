using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner
{
    public partial class RegistrationConfirmation : ContentPage
    {
        EventData? selectedEvent = null;
        UserData? userData = null;

        public RegistrationConfirmation()
        {
            InitializeComponent();

            selectedEvent = SessionData.SelectedEvent;
            userData = SessionData.UserData;

            labelConfirmationMessage.Text = $"Thank you {userData?.UserName ?? "[Unknown Name]"}. " +
                $"You have successfully regisered for the event, {selectedEvent?.Name ?? "[Unknown Event]"}";
        }

        async void OnButtonReturnToMainMenuClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"///{nameof(EventSelection)}");
        }
    }
}
