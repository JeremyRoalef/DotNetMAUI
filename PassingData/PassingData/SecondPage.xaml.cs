using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingData
{
    public partial class SecondPage : ContentPage, IQueryAttributable
    {
        string? UserName = string.Empty;
        string? UserAge = string.Empty;

        public SecondPage()
        {
            InitializeComponent();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("UserName") && query.ContainsKey("UserAge"))
            {
                UserName = query["UserName"].ToString();
                UserAge = query["UserAge"].ToString();

                int userAgeAsInt;
                int.TryParse(UserAge, out userAgeAsInt);

                messageLabel.Text = $"Welcome, {UserName}. You are {UserAge.ToString()} years old.\n";

                if (userAgeAsInt < 18)
                {
                    messageLabel.Text += $"You are a student";
                    messageLabel.TextColor = Colors.Blue;
                }
                else
                {
                    messageLabel.Text += $"You are an adult";
                    messageLabel.TextColor = Colors.Green;
                }
            }
            else
            {
                messageLabel.Text = "Invalid input given...";
            }


        }

        async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
        async void OnButtonThirdPageClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserAge))
            {
                //invalid user name or age
                return;
            }

            string un = UserName.ToString();
            string ua = UserAge.ToString();

            await Shell.Current.GoToAsync(
                nameof(ThirdPage),
                new Dictionary<string, object>
                {
                    {nameof(UserName), UserName },
                    {nameof(UserAge), UserAge }
                }
                );
        }
    }
}
