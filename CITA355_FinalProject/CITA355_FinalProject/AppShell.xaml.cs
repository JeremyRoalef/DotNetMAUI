namespace CITA355_FinalProject
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(CreateAccountPage), typeof(CreateAccountPage));
            Routing.RegisterRoute(nameof(ExamPage), typeof(ExamPage));
            Routing.RegisterRoute(nameof(ResultsPage), typeof(ResultsPage));
            Routing.RegisterRoute(nameof(SearchDatabasePage), typeof(SearchDatabasePage));
        }
    }
}
