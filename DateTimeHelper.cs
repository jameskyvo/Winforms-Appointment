using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Appointment_Scheduler
{
    static internal class DateTimeHelper
    {
        public static TimeZoneInfo tzInfo = TimeZoneInfo.Local;
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
            // Get the time as the users current local time
            TimeZoneInfo easternZone =
        TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime localTime = dtPicker.Value;
            // Convert it to eastern time
            DateTime easternTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(localTime, "Eastern Standard Time");
            // Do logic stuff in EST
            DateTime min = easternTime.Date.AddHours(9); // 9:00 AM
            DateTime max = easternTime.Date.AddHours(17); // 5:00 PM
            

            if (easternTime < min)
            {
                easternTime = min;
            }
            else if (easternTime > max)
            {
                easternTime = max;
            }

            localTime = TimeZoneInfo.ConvertTime(easternTime, easternZone, tzInfo);

            dtPicker.Value = localTime;
        }
    }
}
