
namespace EventPlanner
{
    public partial class EventDetails : ContentPage
    {
        EventData? selectedEvent = null;

        public EventDetails()
        {
            InitializeComponent();

            selectedEvent = SessionData.SelectedEvent;

            //Display the data
            labelEventName.Text = selectedEvent?.Name.ToString() ?? "[Unknown Event Name]";
            labelEventLocation.Text = selectedEvent?.Location.ToString() ?? "[Unknwon Event Location]";
            labelEventDate.Text = selectedEvent?.Date.ToString() ?? "[Unknown Event Date]";
        }
        
        async void OnButtonBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"///{nameof(EventSelection)}");
        }

        async void OnButtonRegisterClicked(object sender, EventArgs e)
        {
            if (selectedEvent != null)
            {
                await Shell.Current.GoToAsync(nameof(Registration));
            }
        }
    }
}
