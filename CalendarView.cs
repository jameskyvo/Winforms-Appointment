using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
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

namespace C969_Appointment_Scheduler
{
    public partial class CalendarView : Form
    {
        private readonly string _connStr;
        MySqlDataRepository _repository;
        private string _userName;
        public BindingList<Customer> _customers;
        public BindingList<Appointment> _appointments = [];
        public BindingList<User> _users = [];
        public CalendarView(string connStr, string userName)
        {
            _connStr = connStr;
            _repository = new(_connStr);
            _userName = userName;

            InitializeComponent();
            _customers = _repository.GetAllCustomers();
            CustomersList.DataSource = _customers;
            CustomersList.DisplayMember = "Name";

            _appointments = _repository.GetAllAppointments();
            AppointmentsGridView.DataSource = _appointments;

            _users = _repository.GetAllUsers();

            TimeZoneLabel.Text = $"Time Zone: {DateTimeHelper.tzInfo}";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new(_connStr, _customers);
            addCustomer.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Customer customer = VerificationHelper.RetrieveValidSelection<Customer>(CustomersList);
            // Open confirmation box to verify if they want to delete the record
            DialogResult result = MessageBox.Show($"Are you sure you want to delete {customer.Name}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);
            // If the user answers yes, try to delete the sql record
            if (result != DialogResult.Yes)
            {
                return;
            }
            // Check to see if any appointments have a customerid matching the customer to delete
            // If so, remove the appointment first.
            try
            {
                _repository.DeleteAppointments(customer);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            //delete the customer from sql
            try
            {
                _repository.DeleteCustomer(customer);
                // if it succeeds, delete the item from the databoundlist.
                _appointments.Clear();

                foreach (var appt in _repository.GetAllAppointments())
                {
                    _appointments.Add(appt);
                }
                _customers.Remove(customer);
            }
            catch (Exception ex)
            {
                // if the sql record fails, pop up the exception in a messagebox
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Customer customer = VerificationHelper.RetrieveValidSelection<Customer>(CustomersList);

            UpdateCustomer updateCustomer = new(_connStr, customer, _customers);
            updateCustomer.Show();
        }

        private void AddAppointmentButton_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new(_customers, _users, _appointments, _repository);
            addAppointment.Show();
        }

        private void DeleteAppButton_Click(object sender, EventArgs e)
        {

            Appointment appointment = VerificationHelper.RetrieveValidSelection<Appointment>(AppointmentsGridView);
            DialogResult result = MessageBox.Show($"Are you sure you want to delete {appointment.Title}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }

            _repository.DeleteAppointment(appointment);
            _appointments.Remove(appointment);
        }

        private void UpdateAppointmentButton_Click(object sender, EventArgs e)
        {
            Appointment appointment = VerificationHelper.RetrieveValidSelection<Appointment>(AppointmentsGridView);
            UpdateAppointment updateAppointment = new(_customers, _users, _appointments, appointment, _repository);
            updateAppointment.Show();
        }

        private void ViewAllAppointmentsButton_Click(object sender, EventArgs e)
        {
            AppointmentsGridView.DataSource = _appointments;
        }

        private void ViewRangeButton_Click(object sender, EventArgs e)
        {
            DateTime start = StartRangePicker.Value;
            DateTime end = EndRangePicker.Value;
            var appointments = _appointments.Where(appointment => appointment.Start > start && appointment.End < end);

            AppointmentsGridView.DataSource = appointments.ToList();
        }

        private void CalendarView_Load(object sender, EventArgs e)
        {
            try
            {

                // Find user's id based off of the username used to sign
                int userId = _repository.GetIdFromUsername(_userName);
                int mins = 15;
                // Get all appointments
                BindingList<Appointment> appointments = _repository.GetAllAppointments();
                // Sort the list to where the appointments are the users and where the appointments are in less than 15 minutes
                var now = DateTime.UtcNow;
                var in15 = now.AddMinutes(15);
                bool hasUpcoming = appointments.Any(a => a.UserId == userId && a.Start.ToUniversalTime() >= now && a.Start.ToUniversalTime() <= in15);

                if (hasUpcoming)
                {
                    MessageBox.Show($"You have an appointment coming up within {mins} minutes.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReportingButton_Click(object sender, EventArgs e)
        {
            Reporting reporting = new(_repository, _users);
            reporting.Show();
        }
    }
}
