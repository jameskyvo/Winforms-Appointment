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
                    City city = new();
                    if (CityDropDown.SelectedItem is City)
                    {
                        city = (City)CityDropDown.SelectedItem;
                    }
                    Address address = new()
                    {
                        StreetAddress = AddressTextBox.Text,
                        SecondaryStreetAddress = Address2TextBox.Text,
                        CityId = city.Id,
                        PostalCode = PostalCodeTextBox.Text,
                        PhoneNumber = PhoneNumberBox.Text,
                        CreateDate = DateTime.UtcNow,
                        CreatedBy = "test",
                        LastUpdate = DateTime.UtcNow,
                        LastUpdatedBy = "test",
                    };
                    // Add address to DB
                    address.Id = _repository.AddAddress(address);
                    // Try to create a customer
                    Customer customer = new()
                    {
                        Name = NameTextBox.Text,
                        AddressId = address.Id,
                        Active = Convert.ToSByte(activeBox.Checked),
                        CreateDate = DateTime.UtcNow,
                        CreatedBy = "test",
                        LastUpdate = DateTime.UtcNow,
                        LastUpdatedBy = "test",
                    };
                    // Add customer to db
                    _repository.AddCustomer(customer, address);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

        }

        private bool CheckValidInput()
        {
            string name = NameTextBox.Text.Trim();
            string address = AddressTextBox.Text.Trim();
            string phoneNumber = PhoneNumberBox.Text.Trim();
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
            string phoneText = PhoneNumberBox.Text;
            if (!PhoneNumberBox.MaskCompleted || phoneText.Contains('_') || phoneText.Contains(' '))
            {
                MessageBox.Show("Please enter a valid phone number.");
                return false;
            }

            string postalCode = PostalCodeTextBox.Text;
            if (!PostalCodeTextBox.MaskCompleted || postalCode.Contains('_') || postalCode.Contains(' '))
            {
                MessageBox.Show("Please enter a valid postal code.");
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
