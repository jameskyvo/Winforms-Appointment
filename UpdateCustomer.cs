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
                    _customers.Remove(_customer);
                    City city = VerificationHelper.RetrieveValidSelection<City>(CityDropDown);
                    Address address = _repository.GetAddressFromCustomer(_customer);
                    // Update address to contain new information
                    address.StreetAddress = AddressTextBox.Text;
                    address.SecondaryStreetAddress = Address2TextBox.Text.Trim();
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
            try
            {
                // Check to make sure the name box is not empty or whitespace
                VerificationHelper.VerifyTextBox(NameTextBox, NameLabel);
                // Check to make sure the address is not empty or whitespace
                VerificationHelper.VerifyTextBox(AddressTextBox, AddressLabel);
                // Check to make sure the phone number does not contain underscores
                VerificationHelper.VerifyMaskedBox(PhoneNumberBox, PhoneNumberLabel);
                // Make sure postal code is valid
                VerificationHelper.VerifyMaskedBox(PostalCodeTextBox, PostalCodeLabel);
                return true;
            } catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                return false;
            }
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
