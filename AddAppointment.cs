using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Appointment_Scheduler
{
    public partial class AddAppointment : Form
    {
        public BindingList<Customer> _customers;
        private readonly BindingList<User> _users;
        public bool _isAdjustingDate = false;
        public bool _isAdjustingTime = false;
        public const int minTime = 9;
        public const int maxTime = 17;

        public AddAppointment(BindingList<Customer> customers, BindingList<User> users)
        {
            InitializeComponent();
            _customers = customers;
            CustomerDropDown.DataSource = _customers;

            _users = users;
            UserDropDown.DataSource = _users;
            EnforceBusinessHours(StartTimePicker.Value, StartTimePicker);
            EnforceBusinessHours(EndTimePicker.Value, EndTimePicker);

        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            bool validInput = CheckValidInput();

            if (validInput)
            {

            }
            // Create a new appointment object and assign respective values

            // Submit to db

            // Add to bindinglist.
        }

        private bool CheckValidInput()
        {
            bool validInput = false;
            DateTime startTime = StartTimePicker.Value;
            DateTime endTime = EndTimePicker.Value;
            try
            {
                // Verify the customer dropbox is selected
                if (CustomerDropDown.SelectedValue == null)
                {
                    MessageBox.Show("The customer dropbox value must be selected.");
                    return validInput;
                }
                // Verify the type Box is not null and is trimmed
                if (string.IsNullOrEmpty(TypeTextBox.Text))
                {
                    MessageBox.Show("Please enter a type.");
                    return validInput;
                }
                // Verify the start time is before the end time
                if (startTime > endTime)
                {
                    MessageBox.Show("The start date cannot be after the end time.");
                    return validInput;
                }
                // Verify both times are between 9 and 5 pm
                return true; //TODO REMOVE
                // Verify the user id is a valid user.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                return false;
            }


        }

        private void StartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (_isAdjustingDate)
            {
                return;
            }

            _isAdjustingDate = true;
            DateTime startDate = StartDatePicker.Value.Date;
            DateTime endDate = EndDatePicker.Value.Date;
            if (startDate > endDate)
            {
                StartDatePicker.Value = EndDatePicker.Value.Date;
            }
            _isAdjustingDate = false;
        }

        private void EnforceBusinessHours(DateTime selectedTime, DateTimePicker dtPicker)
        {
            DateTime min = selectedTime.Date.AddHours(minTime);
            DateTime max = selectedTime.Date.AddHours(maxTime);

            if (selectedTime < min)
            {
                dtPicker.Value = min;
            }
            else if (selectedTime > max)
            {
                dtPicker.Value = max;
            }
        }

        private void EndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (_isAdjustingDate)
            {
                return;
            }

            _isAdjustingDate = true;
            DateTime startDate = StartDatePicker.Value.Date;
            DateTime endDate = EndDatePicker.Value.Date;
            if (startDate > endDate)
            {
                EndDatePicker.Value = StartDatePicker.Value.Date;
            }
            _isAdjustingDate = false;
        }

        private void StartTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (_isAdjustingTime)
            {
                return;
            }

            _isAdjustingTime = true;
            var startTime = StartTimePicker.Value;
            var endTime = EndTimePicker.Value;
            if (startTime > endTime)
            {
                StartTimePicker.Value = EndTimePicker.Value.AddMinutes(-30);
            }
            _isAdjustingTime = false;
        }
    }
}
