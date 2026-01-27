using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Appointment_Scheduler;

public partial class UpdateAppointment : Form
{
    public BindingList<Customer> _customers;
    private readonly BindingList<User> _users;
    private readonly BindingList<Appointment> _appointments;
    public MySqlDataRepository _repository;
    public Appointment _appointment;
    public bool _isAdjustingDate = false;
    public bool _isAdjustingTime = false;
    public UpdateAppointment(BindingList<Customer> customers, BindingList<User> users, BindingList<Appointment> appointments, Appointment currentAppointment, MySqlDataRepository repository)
    {
        InitializeComponent();
        _customers = customers;
        CustomerDropDown.DataSource = _customers;

        _users = users;
        UserDropDown.DataSource = _users;

        _appointments = appointments;
        _appointment = currentAppointment;
        _repository = repository;
        DateTimeHelper.EnforceBusinessHours(StartTimePicker);
        DateTimeHelper.EnforceBusinessHours(EndTimePicker);
    }

    private DateTime CreateDateTime(DateTime date, DateTime time) => date.Date + time.TimeOfDay;

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

    private void UpdateAppointment_Load(object sender, EventArgs e)
    {
        // Fields to preload:
        CustomerDropDown.SelectedValue = _appointment.CustomerId;
        TitleTextBox.Text = _appointment.Title;
        DescriptionTextBox.Text = _appointment.Description;
        TypeTextBox.Text = _appointment.Type;
        LocationTextBox.Text = _appointment.Location;
        ContactTextBox.Text = _appointment.Contact;
        UrlTextBox.Text = _appointment.Url;
        StartDatePicker.Value = _appointment.Start;
        EndDatePicker.Value = _appointment.End;
        StartTimePicker.Value = _appointment.Start;
        EndTimePicker.Value = _appointment.End;
        UserDropDown.SelectedValue = _appointment.UserId;
    }

    private void UpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            bool isValid = CheckValidInput();
            if (isValid)
            {
                DateTime start = CreateDateTime(StartDatePicker.Value, StartTimePicker.Value).ToUniversalTime();
                DateTime end = CreateDateTime(EndDatePicker.Value, EndTimePicker.Value).ToUniversalTime();
                Customer customer = VerificationHelper.RetrieveValidSelection<Customer>(CustomerDropDown);
                User user = VerificationHelper.RetrieveValidSelection<User>(UserDropDown);
                Appointment appointment = new()
                {
                    AppointmentId = _appointment.AppointmentId,
                    CustomerId = customer.Id,
                    UserId = user.Id,
                    Title = TitleTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Location = LocationTextBox.Text,
                    Contact = ContactTextBox.Text,
                    Url = UrlTextBox.Text,
                    Type = TypeTextBox.Text,
                    Start = start,
                    End = end,
                    CreateDate = _appointment.CreateDate,
                    CreatedBy = _appointment.CreatedBy,
                    LastUpdate = DateTime.UtcNow,
                    LastUpdateBy = "test",
                };
                _repository.UpdateAppointment(appointment);
                _appointments.Remove(_appointment);
                _appointments.Add(appointment);
                this.Close();
            } else
            {
                return;
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }
}
