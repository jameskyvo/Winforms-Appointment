using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Data.Odbc;
namespace C969_Appointment_Scheduler
{
    public partial class Login : Form
    {
        readonly RegionInfo currentRegion = RegionInfo.CurrentRegion;
        readonly ResourceManager rm = new("C969_Appointment_Scheduler.Resources.Login", Assembly.GetExecutingAssembly());
        public Login()
        {
            // *** Localization testing for Mexican Spanish. 
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");

            InitializeComponent();

            UsernameLabel.Text = rm.GetString("Username");
            PasswordLabel.Text = rm.GetString("Password");
            LoginButton.Text = rm.GetString("Login");
            this.Text = rm.GetString("Login");
            UserLocationLabel.Text = rm.GetString("UserLocation") + currentRegion;

        }
        

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UsernameBox.Text.Equals("test") && PasswordBox.Text == "test")
            {
                CalendarView cv = new("Server=localhost;Port=3306;Database=customer_schedule;Uid=sqlUser;Password=Passw0rd!");
                cv.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(rm.GetString("LoginFailed"));
            }
        }
    }
}
