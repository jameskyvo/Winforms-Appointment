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
        private readonly string _connStr;
        MySqlDataRepository _repository;
        public AddCustomer(string connStr)
        {
            _connStr = connStr;
            _repository = new(_connStr);
            InitializeComponent();

            CountryDropDown.DataSource = _repository.GetAllCountries();
            CountryDropDown.DisplayMember = "Name";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            bool isValidInput = CheckValidInput();

            if (isValidInput)
            {
                // Try to create an address
                try
                {
                    Address address = new()
                    {
                        StreetAddress = NameTextBox.Text,
                        CountryId = CountryDropDown.

                    };

                }

                // Add address to DB
                // Try to create a customer
                // Add customer to db

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

        private void CityLabel_Click(object sender, EventArgs e)
        {

        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {

        }

        private void CountryDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CountryDropDown.SelectedItem is Country)
            {
                Country country = (Country)CountryDropDown.SelectedItem;
                CityDropDown.DataSource = _repository.RetrieveCitiesInCountry(country.Id);
                CityDropDown.DisplayMember = "Name";

            }
        }
    }
}
