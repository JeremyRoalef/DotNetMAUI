using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITA355_FinalProject
{
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage()
        {
            InitializeComponent();
        }

        async void OnHomeClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
        }

        async void OnLoginClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        async void OnCreateAccountClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CreateAccountPage));
        }

        async void OnSearchDatabaseClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(SearchDatabasePage));
        }
    }
}
