using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner
{
    public partial class Confirmation : ContentPage
    {
        public Confirmation()
        {
            InitializeComponent();
        }

        async void OnButtonReturnToMainMenuClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"///{nameof(EventSelection)}");
        }
    }
}
