using System.Diagnostics;

namespace EventPlanner
{
    public partial class EventSelection : ContentPage
    {
        public EventSelection()
        {
            InitializeComponent();

            AddEventsToLayout();
        }

        private void AddEventsToLayout()
        {
            foreach (KeyValuePair<int, EventData> events in EventData.EVENTS)
            {
                //Get the event data
                EventData eventData = events.Value;

                //Create the event lavel
                Button newEventButton = new Button();
                
                //Listen to when the button is clicked
                newEventButton.Clicked += (object? sender, EventArgs e) => GoToEventDetails(eventData.ID);

                //Set the button's text
                newEventButton.Text = eventData.Name;

                //Add it to the UI
                stackLayout.Add(newEventButton);
            }
        }

        async void GoToEventDetails(int eventID)
        {
            SessionData.SetSelectedEvent(EventData.EVENTS[eventID]);
            await Shell.Current.GoToAsync(nameof(EventDetails));
        }
    }
}
