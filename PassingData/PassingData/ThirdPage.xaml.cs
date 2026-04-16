using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingData
{
    public partial class ThirdPage : ContentPage, IQueryAttributable
    {
        public ThirdPage()
        {
            InitializeComponent();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("UserEmail") )
            {
                emailLabel.Text = query["UserEmail"].ToString();
            }
            else
            {
                emailLabel.Text = "Email not found";
            }

            if (query.ContainsKey("UserName") && query.ContainsKey("UserAge"))
            {
                nameLabel.Text = query["UserName"].ToString();
                ageLabel.Text = query["UserAge"].ToString();
            }
        }

        async void OnButtonGoToMainPageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }
    }
}
