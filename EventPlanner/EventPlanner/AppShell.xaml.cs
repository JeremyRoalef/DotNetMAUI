namespace EventPlanner
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(EventSelection), typeof(EventSelection));
            Routing.RegisterRoute(nameof(EventDetails), typeof(EventDetails));
            Routing.RegisterRoute(nameof(Registration), typeof(Registration));
            Routing.RegisterRoute(nameof(Confirmation), typeof(Confirmation));
            Routing.RegisterRoute(nameof(RegistrationConfirmation), typeof(RegistrationConfirmation));

            //Initialize the event data
            EventData.Initialize();
        }

        async void OnHomeClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"///{nameof(EventSelection)}");
        }

        async void OnEarthDayClicked(object? sender, EventArgs e)
        {
            SessionData.SetSelectedEvent(EventData.EVENTS[2]);
            await Shell.Current.GoToAsync(nameof(EventDetails));
        }

        async void OnBookClubClicked(object? sender, EventArgs e)
        {
            SessionData.SetSelectedEvent(EventData.EVENTS[1]);
            await Shell.Current.GoToAsync(nameof(EventDetails));
        }

        async void OnAppliedStudentLearningClicked(object? sender, EventArgs e)
        {
            SessionData.SetSelectedEvent(EventData.EVENTS[3]);
            await Shell.Current.GoToAsync(nameof(EventDetails));
        }
    }
}
