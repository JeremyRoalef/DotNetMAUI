using MauiAppDB1.Models;
using MauiAppDB1.Services;
using Microsoft.UI.Xaml.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDB1
{
    public partial class UpdateStudent : ContentPage, IQueryAttributable
    {
        Student? student;

        public UpdateStudent()
        {
            InitializeComponent();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            student = (Student)query["student"];

            if (student != null)
            {
                //Initialze entries with existing information
                entryName.Text = student.name;
                entryEmail.Text = student.email;
                entryGPA.Text = student.gpa;
                entryDepartment.Text = student.dept_name;
            }
        }

        async void OnSubmit(object sender, EventArgs e)
        {
            if (student == null) return;

            Student newStudentInfo = new Student(
                student.id, 
                entryName.Text, 
                entryDepartment.Text, 
                entryGPA.Text, 
                entryEmail.Text
                );

            //If there are no changes to the student, then there's no need to waste
            //time updating the entry in the db
            if (newStudentInfo.Equals(student)) return;

            HttpResponseMessage response = await StudentAPI.UpdateStudent(newStudentInfo);

            labelResponse.Text = await response.Content.ReadAsStringAsync();
        }
    }
}
