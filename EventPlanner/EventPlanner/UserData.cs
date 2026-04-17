using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner
{
    public class UserData
    {
        public string UserName { get; private set; }
        public string UserEmail { get; private set; }
        public string UserMNumber { get; private set; }

        public UserData(string userName, string userEmail, string userMNumber)
        {
            this.UserName = userName;
            this.UserEmail = userEmail;
            this.UserMNumber = userMNumber;
        }
    }
}
