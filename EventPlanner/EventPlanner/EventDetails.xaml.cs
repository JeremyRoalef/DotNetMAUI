
namespace EventPlanner
{
    public partial class EventDetails : ContentPage, IQueryAttributable
    {
        int eventID = -1;
        EventData selectedEvent = null;

        public EventDetails()
        {
            InitializeComponent();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            //Get the ID of the passed event
            if (query.ContainsKey("ID"))
            {
                int.TryParse(query["ID"].ToString(), out eventID);
            }

            //Try to find the ID in the event details
            if (EventData.EVENTS.ContainsKey(eventID))
            {
                selectedEvent = EventData.EVENTS[eventID];

                //Display the data
                labelEventName.Text = selectedEvent.Name.ToString();
                labelEventLocation.Text = selectedEvent.Location.ToString();
                labelEventDate.Text = selectedEvent.Date.ToString();
            }
        }

        async void OnButtonBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"///{nameof(EventSelection)}");
        }

        async void OnButtonRegisterClicked(object sender, EventArgs e)
        {
            if (selectedEvent != null)
            {
                await Shell.Current.GoToAsync(
                    nameof(Registration),
                    new Dictionary<string, object>
                    {
                        {"ID", selectedEvent.ID}
                    }
                    );
            }

        }
    }
}
