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
    }
}