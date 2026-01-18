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
    public partial class UpdateCustomer : Form
    {
        private readonly string _connStr;
        MySqlDataRepository _repository;
        public Customer _customer;
        BindingList<Customer> _customers;
        public UpdateCustomer(string connStr, Customer customer, BindingList<Customer> customers)
        {
            _connStr = connStr;
            _repository = new(_connStr);
            _customer = customer;
            InitializeComponent();

            CountryDropDown.DataSource = _repository.GetAllCountries();
            CountryDropDown.DisplayMember = "Name";
            _customers = customers;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            bool isValidInput = CheckValidInput();

            if (isValidInput)
            {
                try
                {
                    if (CityDropDown.SelectedItem is not City || CityDropDown.SelectedItem is null)
                    {
                        MessageBox.Show("Error: Dropdown does not have a valid city selected.");
                        return;
                    }
                    _customers.Remove(_customer);
                    City city = (City)CityDropDown.SelectedItem;
                    Address address = _repository.GetAddressFromCustomer(_customer);
                    // Update address to contain new information
                    address.StreetAddress = AddressTextBox.Text;
                    address.SecondaryStreetAddress = Address2TextBox.Text;
                    address.CityId = city.Id;
                    address.PostalCode = PostalCodeTextBox.Text;
                    address.PhoneNumber = PhoneNumberBox.Text;
                    address.LastUpdate = DateTime.UtcNow;
                    address.LastUpdatedBy = "test";
                    // Add customer to db
                    _repository.UpdateAddress(address);

                    // Update customer to contain new dropdown information
                    _customer.Name = NameTextBox.Text;
                    _customer.AddressId = address.Id;
                    _customer.Active = Convert.ToSByte(activeBox.Checked);
                    _customer.LastUpdate = DateTime.UtcNow;
                    _customer.LastUpdatedBy = "test";
                    // Add customer to db
                    _repository.UpdateCustomer(_customer, address);

                    // Add customer to list
                    _customers.Add(_customer);
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
        private void CountryDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CountryDropDown.SelectedItem is Country)
            {
                Country country = (Country)CountryDropDown.SelectedItem;
                CityDropDown.DataSource = _repository.RetrieveCitiesInCountry(country.Id);
                CityDropDown.DisplayMember = "Name";
            }
        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            Address address = _repository.GetAddressFromCustomer(_customer);
            City city = _repository.GetCityFromAddress(address);
            Country country = _repository.GetCountryFromCity(city);
            // Populate name
            NameTextBox.Text = _customer.Name;
            // Populate country, get country by id
            CountryDropDown.SelectedItem = country;
            // Populate City, get city from address cityid
            CityDropDown.SelectedItem = city;
            // Populate Address
            AddressTextBox.Text = address.StreetAddress;
            // Populate Secondary Address
            Address2TextBox.Text = address.SecondaryStreetAddress;
            // Populate Postal Code
            PostalCodeTextBox.Text = address.PostalCode;
            // Populate Phone Number
            PhoneNumberBox.Text = address.PhoneNumber;
            // Populate Active Box
            if (_customer.Active > 0)
            {
                activeBox.Checked = true;
            }
        }
    }
}
