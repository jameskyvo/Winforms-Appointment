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
        private MySqlDataRepository _repository;
        BindingList<Customer> _customers;
        public AddCustomer(string connStr, BindingList<Customer> customers)
        {
            _connStr = connStr;
            _repository = new(_connStr);
            _customers = customers;
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
                    City city = VerificationHelper.RetrieveValidSelection<City>(CityDropDown);
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
                    customer.Id = Convert.ToInt32(_repository.AddCustomer(customer, address));
                    _customers.Add(customer);
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
    }
}
