using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Appointment_Scheduler
{
    internal class DateTimeHelper
    {
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

        internal static void PreventPastScheduling(DateTimePicker datePicker)
        {
            if (datePicker.Value < DateTime.Now)
            {
                datePicker.Value = DateTime.Now;
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

        internal static void EnforceBusinessHours(DateTimePicker dtPicker)
        {
            DateTime min = dtPicker.Value.Date.AddHours(9); // 9:00 AM
            DateTime max = dtPicker.Value.Date.AddHours(17); // 5:00 PM

            if (dtPicker.Value < min)
            {
                dtPicker.Value = min;
            }
            else if (dtPicker.Value > max)
            {
                dtPicker.Value = max;
            }
        }
    }
}
