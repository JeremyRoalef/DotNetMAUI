namespace MyFirstMAUIApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //register routing to the screensaver page
            Routing.RegisterRoute(nameof(ScreenSaver), typeof(ScreenSaver));
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}