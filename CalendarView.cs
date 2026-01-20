using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace C969_Appointment_Scheduler
{
    public partial class CalendarView : Form
    {
        private readonly string _connStr;
        MySqlDataRepository _repository;
        public BindingList<Customer> _customers;
        public BindingList<Appointment> _appointments = [];
        public CalendarView(string connStr)
        {
            _connStr = connStr;
            _repository = new(_connStr);

            InitializeComponent();
            _customers = _repository.GetAllCustomers();
            CustomersList.DataSource = _customers;
            CustomersList.DisplayMember = "Name";

            _appointments = _repository.GetAllAppointments();
            AppointmentsGridView.DataSource = _appointments;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new(_connStr, _customers);
            addCustomer.Show();
        }

        private void CustomersList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Customer customer = GetSelectedCustomer();
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
            Customer customer = GetSelectedCustomer();

            UpdateCustomer updateCustomer = new(_connStr, customer, _customers);
            updateCustomer.Show();
        }

        private Customer GetSelectedCustomer()
        {
            Customer customer = new();
            if (CustomersList.SelectedItem is Customer)
            {
                customer = (Customer)CustomersList.SelectedItem;
            }

            return customer;
        }

        private void AddAppointmentButton_Click(object sender, EventArgs e)
        {

        }
    }
}
