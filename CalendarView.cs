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
        public CalendarView(string connStr)
        {
            _connStr = connStr;
            _repository = new(_connStr);

            InitializeComponent();
            CustomersList.DataSource = _repository.GetAllCustomers();
            CustomersList.DisplayMember = "Name";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new(_connStr);
            addCustomer.Show();
        }

        private void CustomersList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Customer customer = new();
            // Get the selected object
            if (CustomersList.SelectedItem is Customer)
            {
                customer = (Customer)CustomersList.SelectedItem;
            }
            // Open confirmation box to verify if they want to delete the record
            DialogResult result = MessageBox.Show($"Are you sure you want to delete {customer.Name}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);
            // If the user answers yes, try to delete the sql record
            if (result != DialogResult.Yes)
            {
                return;
            }

            //delete from sql
            try
            {
                _repository.DeleteCustomer(customer);
                // if it succeeds, delete the item from the databoundlist.
                CustomersList.DataSource = _repository.GetAllCustomers();
            }
            catch (Exception ex)
            {
                // if the sql record fails, pop up the exception in a messagebox
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
