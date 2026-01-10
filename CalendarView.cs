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

namespace C969_Appointment_Scheduler
{
    public partial class CalendarView : Form
    {
        private readonly string _connStr;
        public CalendarView(string connStr)
        {
            _connStr = connStr;
            MySqlDataRepository db = new(_connStr);

            InitializeComponent();
            CustomersList.DataSource = db.GetAllCustomers();
            CustomersList.DisplayMember = "Name";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new();
            addCustomer.Show();
        }

        private void CustomersList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
