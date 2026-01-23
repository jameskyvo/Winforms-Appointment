using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Appointment_Scheduler
{
    public class MySqlDataRepository(string connStr)
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

        internal void DeleteAppointments(Customer customer)
        {
            using (MySqlConnection conn = new(_connStr))
            {
                conn.Open();

                string query = @"DELETE FROM appointment
WHERE customerid = @customerid";
                using (MySqlCommand cmd = new(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerid", customer.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal Address GetAddressFromCustomer(Customer customer)
        {
            using MySqlConnection conn = new(_connStr);
            conn.Open();
            string query = @"SELECT * FROM address WHERE addressId = @addressId
LIMIT 1;";
            using (MySqlCommand cmd = new(query, conn))
            {
                cmd.Parameters.AddWithValue("@addressId", customer.AddressId);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Address address = new()
                    {
                        Id = reader.GetInt32("addressId"),
                        StreetAddress = reader.GetString("address"),
                        SecondaryStreetAddress =
    reader.IsDBNull("address2") ? null : reader.GetString("address2"),
                        CityId = reader.GetInt32("cityId"),
                        PostalCode = reader.GetString("postalCode"),
                        PhoneNumber = reader.GetString("phone"),
                        CreateDate = reader.GetDateTime("createDate"),
                        CreatedBy = reader.GetString("createdBy"),
                        LastUpdate = DateTime.UtcNow,
                        LastUpdatedBy = "test"
                    };
                    return address;
                }
            }
            throw new InvalidOperationException($"No address found for addressId {customer.AddressId}");
        }
        internal City GetCityFromAddress(Address address)
        {
            using MySqlConnection conn = new(_connStr);
            conn.Open();
            string query = @"SELECT * FROM city WHERE cityId = @cityId";
            using (MySqlCommand cmd = new(query, conn))
            {
                cmd.Parameters.AddWithValue("@cityId", address.CityId);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    City city = new()
                    {
                        Name = reader.GetString("city"),
                        CountryId = reader.GetInt32("countryId"),
                        CreateDate = reader.GetDateTime("createDate"),
                        CreatedBy= reader.GetString("createdBy"),
                        LastUpdate = DateTime.UtcNow,
                        LastUpdatedBy = "test",
                    };
                    return city;
                }
            }
            throw new InvalidOperationException($"No address found for cityId {address.CityId}");
        }

        internal Country GetCountryFromCity(City city)
        {
            using MySqlConnection conn = new(_connStr);
            conn.Open();
            string query = @"SELECT * FROM country WHERE countryId = @countryId";
            using (MySqlCommand cmd = new(query, conn))
            {
                cmd.Parameters.AddWithValue("@countryId", city.CountryId);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Country country = new()
                    {
                        Name = reader.GetString("country"),
                        CreateDate = reader.GetDateTime("createDate"),
                        CreatedBy = reader.GetString("createdBy"),
                        LastUpdate = DateTime.UtcNow,
                        LastUpdatedBy = "test",
                    };
                    return country;
                }
            }
            throw new InvalidOperationException($"No address found for cityId {city.CountryId}");
        }

        internal void UpdateCustomer(Customer customer, Address address)
        {
            try
            {
                using (MySqlConnection conn = new(_connStr))
                {
                    conn.Open();

                    string query = @"UPDATE customer
SET customerName = @customerName, addressId = @addressId, active = @active, createDate = @createDate, createdBy = @createdBy, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy 
WHERE customerid = @customerId" ;

                    using (MySqlCommand cmd = new(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customer.Id);
                        cmd.Parameters.AddWithValue("@customerName", customer.Name);
                        cmd.Parameters.AddWithValue("@addressId", address.Id);
                        cmd.Parameters.AddWithValue("@active", customer.Active);
                        cmd.Parameters.AddWithValue("@createDate", customer.CreateDate);
                        cmd.Parameters.AddWithValue("@createdBy", customer.CreatedBy);
                        cmd.Parameters.AddWithValue("@lastUpdate", customer.LastUpdate);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", customer.LastUpdatedBy);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show($"Rows affected: {rowsAffected}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        internal void UpdateAddress(Address address)
        {
            try
            {
                using (MySqlConnection conn = new(_connStr))
                {
                    conn.Open();

                    string query = @"UPDATE address
SET address = @address, address2 = @address2, cityId = @cityId, postalCode = @postalCode, phone = @phone, createDate = @createDate, createdBy = @createdBy, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy 
WHERE addressId = @addressId";

                    using (MySqlCommand cmd = new(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@addressId", address.Id);
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        internal BindingList<Appointment> GetAllAppointments()
        {
            BindingList<Appointment> appointments = [];

            using (MySqlConnection conn = new(_connStr))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM appointment";
                    using MySqlCommand cmd = new(query, conn);
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Appointment appointment = new()
                        {
                            AppointmentId = reader.GetInt32("appointmentId"),
                            CustomerId = reader.GetInt32("customerId"),
                            UserId = reader.GetInt32("userId"),
                            Title = reader.GetString("title"),
                            Description = reader.IsDBNull("description") ? null : reader.GetString("description"),
                            Location = reader.GetString("location"),
                            Contact = reader.GetString("contact"),
                            Type = reader.GetString("type"),
                            Url = reader.IsDBNull("url") ? null : reader.GetString("url"),
                            Start = reader.GetDateTime("start"),
                            End = reader.GetDateTime("end"),
                            CreateDate = reader.GetDateTime("createDate"),
                            CreatedBy = reader.GetString("createdBy"),
                            LastUpdate = reader.GetDateTime("lastUpdate"),
                            LastUpdateBy = reader.GetString("lastUpdateBy"),
                        };

                        appointments.Add(appointment);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return appointments;
        }

        internal BindingList<User> GetAllUsers()
        {
            BindingList<User> users = [];

            using (MySqlConnection conn = new(_connStr))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM user";
                    using MySqlCommand cmd = new(query, conn);
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new()
                        {
                            Id = reader.GetInt32("userid"),
                            UserName = reader.GetString("userName"),
                            Password = reader.GetString("password"),
                            Active = reader.GetSByte("active"),
                            CreateDate = reader.GetDateTime("createDate"),
                            CreatedBy = reader.GetString("createdBy"),
                            LastUpdate = reader.GetDateTime("lastUpdate"),
                            LastUpdatedBy = reader.GetString("lastUpdateBy"),
                        };

                        users.Add(user);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return users;
        }

        public void AddAppointment(Appointment appointment)
        {
            using (MySqlConnection conn = new(_connStr))
            {
                conn.Open();

                string query = @"INSERT INTO appointment
(customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)
VALUES
(@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

                using (MySqlCommand cmd = new(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerId", appointment.CustomerId);
                    cmd.Parameters.AddWithValue("@userId", appointment.UserId);
                    cmd.Parameters.AddWithValue("@title", appointment.Title);
                    cmd.Parameters.AddWithValue("@description", appointment.Description);
                    cmd.Parameters.AddWithValue("@location", appointment.Location);
                    cmd.Parameters.AddWithValue("@contact", appointment.Contact);
                    cmd.Parameters.AddWithValue("@type", appointment.Type);
                    cmd.Parameters.AddWithValue("@url", appointment.Url);
                    cmd.Parameters.AddWithValue("@start", appointment.Start);
                    cmd.Parameters.AddWithValue("@end", appointment.End);
                    cmd.Parameters.AddWithValue("@createDate", appointment.CreateDate);
                    cmd.Parameters.AddWithValue("@createdBy", appointment.CreatedBy);
                    cmd.Parameters.AddWithValue("@lastUpdate", appointment.LastUpdate);
                    cmd.Parameters.AddWithValue("@lastUpdateBy", appointment.LastUpdateBy);
                    
                    cmd.ExecuteNonQuery();
                    appointment.AppointmentId = (int)cmd.LastInsertedId;
                }
            }
        }
    }
}