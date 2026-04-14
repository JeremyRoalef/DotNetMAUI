using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingData
{
    public partial class SecondPage : ContentPage, IQueryAttributable
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            nameLabel.Text = $"Name: {query["UserName"]}";
            if (query.ContainsKey("UserAge"))
            {
                ageLabel.Text = $"Age: {query["UserAge"]}";
            }
        }

        async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
