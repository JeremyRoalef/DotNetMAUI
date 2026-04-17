using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner
{
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }

        async void OnButtonBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(EventDetails)}");
        }

        async void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Confirmation));
        }
    }
}
