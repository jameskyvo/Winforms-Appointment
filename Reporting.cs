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
    public partial class Reporting : Form
    {
        private MySqlDataRepository _repository;
        private object _users;
        public BindingList<Appointment> _appointments;

        public Reporting(MySqlDataRepository repository, BindingList<User> users)
        {
            _repository = repository;
            _users = users;
            _appointments = _repository.GetAllAppointments();
            InitializeComponent();

            UserDropdownBox.DataSource = _users;
            UserDropdownBox.DisplayMember = "userName";
        }
        private void CheckUserScheduleButton_Click(object sender, EventArgs e)
        {
            // Given a user, get all the appointments they're enrolled in.
            // Get selected user
            VerificationHelper.VerifyDropdown(UserDropdownBox, ConsultantLabel);
            User user = VerificationHelper.RetrieveValidSelection<User>(UserDropdownBox);
            // Get every appointment where the userId is equal to the userid on the appointment
            var tempAppointments = _appointments.Where(a => a.UserId == user.Id && a.Start.ToUniversalTime() > DateTime.UtcNow);
            // Display all selected appointments in dgv.
            UserScheduleDGV.DataSource = new BindingList<Appointment>(tempAppointments.ToList());
        }

        private void NumberOfFutureAppointmentsButton_Click(object sender, EventArgs e)
        {
            var tempAppointments = _appointments.Where(a => a.Start.ToUniversalTime() > DateTime.UtcNow);
            FutureAppointmentsLabel.Text = $"Total Future Appointments: {tempAppointments.Count()}";
        }

        private void NumberOfTypesByMonthButton_Click(object sender, EventArgs e)
        {
            List<string> types = new();
            // Get the current month of the dropdown
            var currentMonth = MonthPicker.Value.Month;
            // Get a list of appointments where the month is equal to the selected month
            var appointmentsThisMonth = _appointments.Where(a => a.Start.Month == currentMonth || a.End.Month == currentMonth);
            // For each month in the list, get the type and add it to a separate list.
            foreach (Appointment appointment in appointmentsThisMonth)
            {
                string type = appointment.Type;
                types.Add(type);
            }
            // Count the occurrence of each type in the list
            var counts = types.GroupBy(t => t).ToDictionary(d => d.Key, g => g.Count());

            BindingList<string> formattedTypes = new();
            foreach (var kvp in counts)
            {
                formattedTypes.Add($"{kvp.Key}: {kvp.Value}");
            }

            TypesListBox.DataSource = formattedTypes;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
