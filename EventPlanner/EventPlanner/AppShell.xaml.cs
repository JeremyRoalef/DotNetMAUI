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
        }
    }
}
