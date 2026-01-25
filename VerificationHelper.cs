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

        internal static T RetrieveValidSelection<T>(ComboBox comboBox) where T : class
        {
            if (comboBox.SelectedItem is not T value)
            {
                throw new ArgumentException(
                    $"Dropdown does not have a valid {typeof(T).Name} selected.");
            }
            return value;
        }
        internal static T RetrieveValidSelection<T>(ListBox listBox) where T : class
        {
            if (listBox.SelectedItem is not T value)
            {
                throw new ArgumentException(
                    $"Listbox does not have a valid {typeof(T).Name} selected.");
            }
            return value;
        }
        internal static T RetrieveValidSelection<T>(DataGridView dgv) where T : class
        {
            if (dgv.CurrentRow.DataBoundItem is not T value)
            {
                throw new ArgumentException(
                    $"Data grid view does not have a valid {typeof(T).Name} selected.");
            }
            return value;
        }
    }
}
