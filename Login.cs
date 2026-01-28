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
        public string _connStr = "Server=127.0.0.1;Port=3306;Database=client_schedule;Uid=sqlUser;Password=Passw0rd!";
        MySqlDataRepository _repository;
        private BindingList<User> _users;

        public Login()
        {
            // *** Localization testing for Mexican Spanish. 
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");

            InitializeComponent();
            _repository = new(_connStr);
            _users = _repository.GetAllUsers();
            UsernameLabel.Text = rm.GetString("Username");
            PasswordLabel.Text = rm.GetString("Password");
            LoginButton.Text = rm.GetString("Login");
            this.Text = rm.GetString("Login");
            UserLocationLabel.Text = rm.GetString("UserLocation") + currentRegion;

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            bool validLogin = false;
            // Foreach user in db
            foreach(User user in _users)
            {
                // if the user's username = usernamebox && the user's password == passwordbox, login.
                if (user.UserName == UsernameBox.Text && user.Password == PasswordBox.Text)
                {
                    validLogin = true;
                    string userName = UsernameBox.Text;
                    CalendarView cv = new(_connStr, userName);
                    cv.Show();
                    // Open Login_History.txt, create if not existing with RW permissions
                    using (StreamWriter w = File.AppendText("Login_History.txt"))
                        w.WriteLine($"{DateTime.UtcNow} - {userName}");
                    this.Hide();
                    return;
                }
            }

            if (validLogin == false)
            {
                MessageBox.Show("Login information is incorrect.");
            }
        }
    }
}
