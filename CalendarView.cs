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
        public CalendarView()
        {
            InitializeComponent();

            string connStr = "Server=localhost;Database=customer_schedule;Uid=root";

            MySqlDataRepository dbRepo = new MySqlDataRepository(connStr);


            var addresses = dbRepo.Query("SELECT * FROM ADDRESS;", "address");

            foreach (var address in addresses)
            {
                MessageBox.Show(address);
            }

        }
    }
}
