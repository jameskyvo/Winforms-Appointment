using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Appointment_Scheduler
{
    internal class MySqlDataRepository(string connStr)
    {
        private readonly string _connStr = connStr;
        public long AddAddress(Address address)
        {
            using (MySqlConnection conn = new(_connStr))
            {
                conn.Open();

                string query = @"INSERT INTO address
(address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy)
VALUES
(@address, @address2, @cityId, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

                using (MySqlCommand cmd = new(query, conn))
                {
                    cmd.Parameters.AddWithValue("@address", address.StreetAddress);
                    cmd.Parameters.AddWithValue("@address2", address.SecondaryStreetAddress);
                    cmd.Parameters.AddWithValue("@cityId", address.CityId);
                    cmd.Parameters.AddWithValue("@postalCode", address.PostalCode);
                    cmd.Parameters.AddWithValue("@phone", address.PhoneNumber);
                    cmd.Parameters.AddWithValue("@createDate", address.CreateDate);
                    cmd.Parameters.AddWithValue("@createdBy", address.CreatedBy);
                    cmd.Parameters.AddWithValue("@lastUpdate", address.LastUpdate);
                    cmd.Parameters.AddWithValue("@lastUpdateBy", address.LastUpdatedBy);

                    cmd.ExecuteNonQuery();

                    return cmd.LastInsertedId;
                }
            }
        }
        public BindingList<Country> GetAllCountries()
        {
            BindingList<Country> countries = [];

            using (MySqlConnection conn = new(_connStr))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM country";
                    using MySqlCommand cmd = new(query, conn);
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Country country = new()
                        {
                            Id = reader.GetInt32("countryId"),
                            Name = reader.GetString("country"),
                            CreateDate = reader.GetDateTime("createDate"),
                            CreatedBy = reader.GetString("createdBy"),
                            LastUpdate = reader.GetDateTime("lastUpdate"),
                            LastUpdatedBy = reader.GetString("lastUpdateBy")
                        };

                        countries.Add(country);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return countries;
        }

        public BindingList<City> RetrieveCitiesInCountry(int countryId)
        {
            BindingList<City> cities = [];

            using (MySqlConnection conn = new(_connStr))
            {
                try
                {
                    conn.Open();

                    string query = $"SELECT * FROM city WHERE countryId = {countryId}";
                    using MySqlCommand cmd = new(query, conn);
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        City city = new()
                        {
                            Id = reader.GetInt32("cityId"),
                            Name = reader.GetString("city"),
                            CountryId = reader.GetInt32("countryId"),
                            CreateDate = reader.GetDateTime("createDate"),
                            CreatedBy = reader.GetString("createdBy"),
                            LastUpdate = reader.GetDateTime("lastUpdate"),
                            LastUpdatedBy = reader.GetString("lastUpdateBy")
                        };

                        cities.Add(city);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return cities;
        }

        public BindingList<Customer> GetAllCustomers()
        {
            BindingList<Customer> customers = [];

            using (MySqlConnection conn = new(_connStr))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM customer";
                    using MySqlCommand cmd = new(query, conn);
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
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

                        customers.Add(customer);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return customers;
        }

        internal void AddCustomer(Customer customer, Address address)
        {
            try
            {
                using (MySqlConnection conn = new(_connStr))
                {
                    conn.Open();

                    string query = @"INSERT into customer
(customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy)
VALUES
(@customerName, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

                    using (MySqlCommand cmd = new(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerName", customer.Name);
                        cmd.Parameters.AddWithValue("@addressId", address.Id);
                        cmd.Parameters.AddWithValue("@active", customer.Active);
                        cmd.Parameters.AddWithValue("@createDate", customer.CreateDate);
                        cmd.Parameters.AddWithValue("@createdBy", customer.CreatedBy);
                        cmd.Parameters.AddWithValue("@lastUpdate", customer.LastUpdate);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", customer.LastUpdatedBy);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        internal void DeleteCustomer(Customer customer)
        {
            using (MySqlConnection conn = new(_connStr))
            {
                conn.Open();

                string query = @"DELETE FROM customer
WHERE customerid = @customerid";
                using (MySqlCommand cmd = new(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerid", customer.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}