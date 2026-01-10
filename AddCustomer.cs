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
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            bool isValidInput = CheckValidInput();

            if (isValidInput)
            {
                Customer customer = new()
                {
                    Id = reader.GetInt32("customerid"),
                    Name = reader.GetString("customerName"),
                    AddressId = reader.GetInt32("addressId"),
                    Active = reader.GetSByte("active"),
                    CreateDate = reader.GetDateTime("createDate"),
                    CreatedBy = reader.GetString("createdBy"),
                    LastUpdate = reader.GetDateTime("lastUpdate"),
                    LastUpdatedBy = reader.GetString("lastUpdateBy")
                };
            }

        }

        private bool CheckValidInput()
        {
            string name = NameTextBox.Text;
            string address = AddressTextBox.Text;
            string phoneNumber = PhoneNumberBox.Text;
            // Check to make sure the name box is not empty or whitespace
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a customer's name.");
                return false;
            }
            // Check to make sure the address is not empty or whitespace
            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Please enter an address.");
                return false;
            }
            // Check to make sure the phone number does not contain underscores
            if (!PhoneNumberBox.MaskCompleted)
            {
                MessageBox.Show("Please enter a valid phone number.");
                return false;
            }

            return true;
        }
    }
}
