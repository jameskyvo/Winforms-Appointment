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
        private readonly BindingList<Appointment> _appointments;
        public MySqlDataRepository _repository;
        public bool _isAdjustingDate = false;
        public bool _isAdjustingTime = false;
        public const int minTime = 9;
        public const int maxTime = 17;

        public AddAppointment(BindingList<Customer> customers, BindingList<User> users, BindingList<Appointment> appointments, MySqlDataRepository repository)
        {
            InitializeComponent();
            _customers = customers;
            CustomerDropDown.DataSource = _customers;

            _users = users;
            UserDropDown.DataSource = _users;

            _appointments = appointments;
            _repository = repository;
            DateTimeHelper.EnforceBusinessHours(StartTimePicker);
            DateTimeHelper.EnforceBusinessHours(EndTimePicker);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool validInput = CheckValidInput();
                Customer customer = VerificationHelper.RetrieveValidSelection<Customer>(CustomerDropDown);
                User user = VerificationHelper.RetrieveValidSelection<User>(UserDropDown);
                {
                    if (validInput)
                    {
                        // Create a new appointment object and assign respective values
                        Appointment appointment = new()
                        {
                            CustomerId = customer.Id,
                            UserId = user.Id,
                            Title = TitleTextBox.Text,
                            Description = DescriptionTextBox.Text.Trim(),
                            Location = LocationTextBox.Text.Trim(),
                            Contact = ContactTextBox.Text.Trim(),
                            Type = TypeTextBox.Text,
                            Url = UrlTextBox.Text.Trim(),
                            Start = CreateDateTime(StartDatePicker.Value, StartTimePicker.Value).ToUniversalTime(),
                            End = CreateDateTime(EndDatePicker.Value, EndTimePicker.Value).ToUniversalTime(),
                            CreateDate = DateTime.UtcNow,
                            CreatedBy = "test",
                            LastUpdate = DateTime.UtcNow,
                            LastUpdateBy = "test",

                        };
                        // Submit to db
                        _repository.AddAppointment(appointment);
                        // Add to bindinglist.

                        // Convert back to local
                        appointment.Start = appointment.Start.ToLocalTime();
                        appointment.End = appointment.End.ToLocalTime();
                        _appointments.Add(appointment);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private static DateTime CreateDateTime(DateTime date, DateTime time) => date.Date + time.TimeOfDay;

        private bool CheckValidInput()
        {
            bool validInput = false;
            try
            {
                // Ensure values are not null and are trimmed.
                VerificationHelper.VerifyDropdown(CustomerDropDown, CustomerLabel);
                VerificationHelper.VerifyTextBox(TitleTextBox, TitleLabel);
                VerificationHelper.VerifyTextBox(DescriptionTextBox, DescriptionLabel);
                VerificationHelper.VerifyTextBox(TypeTextBox, TypeLabel);
                VerificationHelper.VerifyTextBox(LocationTextBox, LocationLabel);
                VerificationHelper.VerifyTextBox(ContactTextBox, ContactLabel);
                // VerificationHelper.VerifyTextBox(UrlTextBox, UrlLabel); URL is assumed to be nullable.
                VerificationHelper.VerifyDropdown(UserDropDown, UserIdLabel);
                validInput = true;
                return validInput;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                validInput = false;
                return validInput;
            }
        }

        private void StartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (_isAdjustingDate)
            {
                return;
            }

            _isAdjustingDate = true;
            DateTimeHelper.EnforceBusinessDays(StartDatePicker);
            DateTimeHelper.EnforceEndDateAfterStartDate(StartDatePicker, EndDatePicker);
            DateTimeHelper.PreventPastScheduling(StartDatePicker);
            _isAdjustingDate = false;
        }

        private void EndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (_isAdjustingDate)
            {
                return;
            }

            _isAdjustingDate = true;
            DateTimeHelper.EnforceBusinessDays(EndDatePicker);
            DateTimeHelper.EnforceEndDateAfterStartDate(StartDatePicker, EndDatePicker);
            DateTimeHelper.PreventPastScheduling(StartDatePicker);
            _isAdjustingDate = false;
        }

        private void StartTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (_isAdjustingTime)
            {
                return;
            }

            _isAdjustingTime = true;
            DateTimeHelper.EnforceBusinessHours(StartTimePicker);
            DateTimeHelper.EnforceEndTimeAfterStartTime(StartTimePicker, EndTimePicker);
            _isAdjustingTime = false;
        }

        private void EndTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (_isAdjustingTime)
            {
                return;
            }

            _isAdjustingTime = true;
            DateTimeHelper.EnforceBusinessHours(EndTimePicker);
            DateTimeHelper.EnforceStartTimeBeforeEndTime(StartTimePicker, EndTimePicker);
            _isAdjustingTime = false;
        }

        private void CancelOutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
