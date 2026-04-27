using MauiAppDB1.Models;
using MauiAppDB1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDB1
{
    public partial class AddStudent : ContentPage
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        async void OnSubmitClicked(object sender, EventArgs e)
        {
            //Get the student info from the entry fields
            Student studentInfo = new Student(
                entryID.Text,
                entryName.Text,
                entryDeptName.Text,
                entryGPA.Text,
                entryEmail.Text
                );

            //Validate student information
            if (string.IsNullOrWhiteSpace(studentInfo.id) ||
                string.IsNullOrWhiteSpace(studentInfo.name) ||
                string.IsNullOrWhiteSpace(studentInfo.dept_name) ||
                string.IsNullOrWhiteSpace(studentInfo.gpa) ||
                string.IsNullOrWhiteSpace(studentInfo.email)
                )
            {
                //values are not valid
                return;
            }

            //Validate numbers to ensure they are real numbers
            if (!int.TryParse(studentInfo.id, out int _) || 
                !float.TryParse(studentInfo.gpa, out float _)){
                //Either the ID or GPA is not validated. Data isn't valid
                return;
            }

            //Validate the email for proper format
            if (!MailAddress.TryCreate(entryEmail.Text, out _))
            {
                //Could not create a mail address from the given email string
                return;
            }

            //All student information is valid. Send to the server
            HttpResponseMessage response = await StudentAPI.AddStudent(studentInfo);
            labelResponse.Text = await response.Content.ReadAsStringAsync();
        }
    }
}
