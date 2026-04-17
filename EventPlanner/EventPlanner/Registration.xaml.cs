using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace EventPlanner
{
    public partial class Registration : ContentPage, IQueryAttributable
    {
        static int M_NUMBER_LENGTH = 9;

        EventData? selectedEvent = null;

        public Registration()
        {
            InitializeComponent();

            entryFullName.Unfocused += HandleNameUnfocused;
            entryMNumber.Unfocused += HandleMNumberUnfocused;
            entryEmail.Unfocused += HandleEmailUnfocused;
        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int eventID = -1;

            //Get the ID of the passed event
            if (query.ContainsKey("ID"))
            {
                int.TryParse(query["ID"].ToString(), out eventID);
            }

            //Try to find the ID in the event details
            if (EventData.EVENTS.ContainsKey(eventID))
            {
                selectedEvent = EventData.EVENTS[eventID];

                //Display the event's name
                labelEventName.Text = $"Registration for {selectedEvent.Name}";
            }
        }

        private void HandleNameUnfocused(object? sender, FocusEventArgs e)
        {
            //If name is not valid, then display the invalid name label
            labelInvalidName.IsVisible = !IsValidName();
        }

        private void HandleMNumberUnfocused(object? sender, FocusEventArgs e)
        {
            //if M# is not valid, then display the invalid M# label
            labelInvalidMNumber.IsVisible = !IsValidMNumber();
        }

        private void HandleEmailUnfocused(object? sender, FocusEventArgs e)
        {
            //If email was invalid, then display the invalid email label
            labelInvalidEmail.IsVisible = !IsValidEmail();
        }

        bool IsValidEmail()
        {
            //If string is null or white space, then no email was given
            if (string.IsNullOrWhiteSpace(entryEmail.Text)) return false;

            //Try to create a mail address from the passed email. If it doesn't create, then email was not valid
            if (!MailAddress.TryCreate(entryEmail.Text, out _))
            {
                //Could not create a mail address from the given email string
                return false;
            }

            //Email was found to be valid
            return true;
        }

        bool IsValidMNumber()
        {
            //If M# is null or white space, then no M# was given
            if (string.IsNullOrWhiteSpace(entryMNumber.Text)) return false;
            if (entryMNumber.Text.Length != M_NUMBER_LENGTH) return false;

            //Separate the M# into two parts: the M starting symbol and the rest of the string

            //If the first character isn't M (for the M#), then M# is invalid
            char firstCharacter = entryMNumber.Text[0];
            if (firstCharacter != 'M') return false;

            //If all characters after M is not a number, then M# is invalid
            string numeralPartOfMNumber = entryMNumber.Text.Substring(1);
            if (!int.TryParse(numeralPartOfMNumber, out int _)) return false;

            //M# was found to be valid
            return true;
        }

        bool IsValidName()
        {
            //Check if name is empty or is only white space
            if (string.IsNullOrWhiteSpace(entryFullName.Text)) return false;

            //If the name contains any characters not in the alphabet (or white space), then the name isn't actually valid
            foreach (char c in entryFullName.Text)
            {
                //If the character is a letter or white space, then it's valid
                if (char.IsLetter(c) || char.IsWhiteSpace(c)) continue;

                //Character is not valid
                return false;
            }

            //Name was found to be valid
            return true;
        }

        async void OnButtonBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(EventDetails)}");
        }

        async void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            bool isValidName = IsValidName();
            bool isValidEmail = IsValidEmail();
            bool isValidMNumber = IsValidMNumber();

            labelInvalidName.IsVisible = !isValidName;
            labelInvalidEmail.IsVisible = !isValidEmail;
            labelInvalidMNumber.IsVisible = !isValidMNumber;

            if (isValidName && isValidEmail && isValidMNumber)
            {
                await Shell.Current.GoToAsync(nameof(Confirmation),
                    new Dictionary<string, object>
                    {
                        {"ID", selectedEvent.ID},
                        {"UserName", entryFullName.Text},
                        {"UserEmail", entryEmail.Text },
                        {"UserMNumber", entryMNumber.Text}
                    }
                    );
            }
        }
    }
}
