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
            EnforceBusinessHours(StartTimePicker.Value, StartTimePicker);
            EnforceBusinessHours(EndTimePicker.Value, EndTimePicker);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool validInput = CheckValidInput();
                Customer customer = RetrieveValidCustomer();
                User user = RetrieveValidUser();
                {
                    // Create a new appointment object and assign respective values
                    Appointment appointment = new()
                    {
                        CustomerId = customer.Id,
                        UserId = user.Id,
                        Title = TitleTextBox.Text,
                        Description = DescriptionTextBox.Text,
                        Location = LocationBox.Text,
                        Contact = ContactTextBox.Text,
                        Type = TypeTextBox.Text,
                        Url = UrlTextBox.Text,
                        // TODO: COMBINE START DATE AND TIME TOGETHER TO SET START AND
                        Start = CreateDateTime(StartDatePicker.Value, StartTimePicker.Value),
                        End = CreateDateTime(EndDatePicker.Value, EndDatePicker.Value),
                        CreateDate = DateTime.UtcNow,
                        CreatedBy = "test",
                        LastUpdate = DateTime.UtcNow,
                        LastUpdateBy = "test",

                    };
                    // Submit to db
                    _repository.AddAppointment(appointment);
                    // Add to bindinglist.
                    _appointments.Add(appointment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private DateTime CreateDateTime(DateTime date, DateTime time)
        {
            DateTime dateOnly = date.Date;
            DateTime timeOnly = time;

            DateTime combined = dateOnly.Date + timeOnly.TimeOfDay;

            return combined;
        }

        private User RetrieveValidUser()
        {
            if (UserDropDown.SelectedItem is not User || UserDropDown.SelectedItem is null)
            {
                throw new ArgumentException("Dropdown does not have a valid user selected.");
            }
            else
            {
                return (User)UserDropDown.SelectedItem;
            }
        }

        private Customer RetrieveValidCustomer()
        {
            if (CustomerDropDown.SelectedItem is not Customer || CustomerDropDown.SelectedItem is null)
            {
                throw new ArgumentException("Dropdown does not have a valid customer selected.");
            }
            else
            {
                return (Customer)CustomerDropDown.SelectedItem;
            }
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
                if (string.IsNullOrEmpty(TypeTextBox.Text) || string.IsNullOrWhiteSpace(TypeTextBox.Text))
                {
                    MessageBox.Show("Please enter a type.");
                    return validInput;
                }
                // Verify the user id is a valid user.
                if (UserDropDown.SelectedValue == null)
                {
                    MessageBox.Show("The user dropbox value must be selected.");
                    return validInput;
                }
                validInput = true;
                return validInput;
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

            if (startDate.DayOfWeek == DayOfWeek.Saturday)
            {
                StartDatePicker.Value = startDate.AddDays(2);
            }
            else if (startDate.DayOfWeek == DayOfWeek.Sunday)
            {
                StartDatePicker.Value = startDate.AddDays(1);
            }
            if (startDate > endDate)
            {
                EndDatePicker.Value = StartDatePicker.Value.Date;
            }
            if (startDate < DateTime.Now)
            {
                StartDatePicker.Value = DateTime.Now;
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
            if (endDate.DayOfWeek == DayOfWeek.Saturday)
            {
                EndDatePicker.Value = endDate.AddDays(2);
            }
            else if (endDate.DayOfWeek == DayOfWeek.Sunday)
            {
                EndDatePicker.Value = endDate.AddDays(1);
            }
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
                EndTimePicker.Value = StartTimePicker.Value.AddMinutes(30);
            }
            _isAdjustingTime = false;
        }

        private void EndTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (_isAdjustingTime)
            {
                return;
            }

            _isAdjustingTime = true;
            var startTime = StartTimePicker.Value;
            var endTime = EndTimePicker.Value;
            if (endTime < startTime)
            {
                EndTimePicker.Value = StartTimePicker.Value.AddMinutes(30);
            }
            _isAdjustingTime = false;
        }
    }
}
