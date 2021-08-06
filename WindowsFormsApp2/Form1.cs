using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Classes;
using Microsoft.EntityFrameworkCore;
using SampleLibraryCore.Data;
using SampleLibraryCore.Extensions;
using SampleLibraryCore.Models;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Employee to work with
        /// </summary>
        private int identifier = 7;
        
        public Form1()
        {
            InitializeComponent();
            Shown += OnShown;
        }

        /// <summary>
        /// When this form is displayed get employee with an id of <see cref="identifier"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnShown(object sender, EventArgs e)
        {
            await Task.Delay(500);

            try
            {
                var employee = await NorthWindOperations.ReadEmployee(identifier);

                FirstNameTextBox.Text = employee.FirstName;
                LastNameTextBox.Text = employee.LastName;


                FirstNameTextBox.SelectionStart = FirstNameTextBox.Text.Length;
                FirstNameTextBox.SelectionLength = 0;
                SaveButton.Enabled = true;
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }


        /// <summary>
        /// Save employee with id <see cref="identifier"/>
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e"><see cref="EventArgs"/></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            /*
             * Simple assertion to ensure both first and last name have values
             */
            if (Controls.OfType<TextBox>().Any(textbox => string.IsNullOrWhiteSpace(textbox.Text)))
            {
                MessageBox.Show("First and last name are reqired");
                ResetEmployee();

                return;
            }

            /*
             * Create a new instance of an Employee and set the primary key so Entity Framework
             * knows which record to update first and last name
             */
            Employee employee = new ()
            {
                EmployeeId = identifier,
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text
            };


            try
            {
                var success = NorthWindOperations.SaveEmployee(employee);
                MessageBox.Show(success ? "Saved" : "Failed");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Reset Employee from database current first and last names
        /// </summary>
        private void ResetEmployee()
        {
            Employee originalEmployee = NorthWindOperations.OriginalEmployee(identifier);
            
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                FirstNameTextBox.Text = originalEmployee.FirstName;
            }

            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                LastNameTextBox.Text = originalEmployee.LastName;
            }
        }
    }
}
