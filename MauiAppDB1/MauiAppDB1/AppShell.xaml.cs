namespace MauiAppDB1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddStudent), typeof(AddStudent));
            Routing.RegisterRoute(nameof(UpdateStudent), typeof(UpdateStudent));
        }
    }
}
