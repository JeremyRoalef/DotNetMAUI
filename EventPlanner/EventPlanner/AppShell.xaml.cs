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
        }

        async void OnHomeClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"///{nameof(EventSelection)}");
        }

        async void OnEarthDayClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(EventDetails),
                new Dictionary<string, object>
                {
                    {"ID", 2}
                }
                );
        }

        async void OnBookClubClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(EventDetails),
                new Dictionary<string, object>
                {
                    {"ID", 1 }
                }
                );
        }

        async void OnAppliedStudentLearningClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(EventDetails),
                new Dictionary<string, object>
                {
                    { "ID", 3}
                }
                );
        }
    }
}
