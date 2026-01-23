using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Appointment_Scheduler
{
    public static class VerificationHelper
    {
        public static void VerifyTextBox(TextBox tb, Label label)
        {
            if (string.IsNullOrEmpty(tb.Text) || string.IsNullOrWhiteSpace(tb.Text))
            {
                throw new InvalidEnumArgumentException($"Please enter a {label.Text}");
            } else
            {
                tb.Text = tb.Text.Trim();
            }
        }
        public static void VerifyDropdown(ComboBox cb, Label label)
        {
            if (cb.SelectedValue == null)
            {
                throw new InvalidEnumArgumentException($"{label.Text} dropdown must be selected.");
            }
        }

        internal static void EnforceBusinessDays(DateTimePicker dtpicker)
        {
            if (dtpicker.Value.DayOfWeek == DayOfWeek.Saturday)
            {
                dtpicker.Value = dtpicker.Value.AddDays(2);
            }
            else if (dtpicker.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                dtpicker.Value = dtpicker.Value.AddDays(1);
            }
        }

        internal static void EnforceEndDateAfterStartDate(DateTimePicker startDatePicker, DateTimePicker endDatePicker)
        {
            if (startDatePicker.Value > endDatePicker.Value)
            {
                endDatePicker.Value = startDatePicker.Value;
            }
        }

        internal static void PreventPastScheduling(DateTimePicker startDatePicker)
        {
            if (startDatePicker.Value < DateTime.Now)
            {
                startDatePicker.Value = DateTime.Now;
            }
        }

        internal static void EnforceEndTimeAfterStartTime(DateTimePicker startTimePicker, DateTimePicker endTimePicker)
        {
            if (startTimePicker.Value > endTimePicker.Value)
            {
                endTimePicker.Value = startTimePicker.Value.AddMinutes(30);
            }
        }

        internal static void EnforceStartTimeBeforeEndTime(DateTimePicker startTimePicker, DateTimePicker endTimePicker)
        {
            if (startTimePicker.Value > endTimePicker.Value)
            {
                startTimePicker.Value = endTimePicker.Value.AddMinutes(-30);
            }
        }

        internal static T RetrieveValidSelection<T>(ComboBox comboBox) where T : class
        {
            if (comboBox.SelectedItem is not T value)
            {
                throw new ArgumentException(
                    $"Dropdown does not have a valid {typeof(T).Name} selected.");
            }
            return value;
        }
    }
}
