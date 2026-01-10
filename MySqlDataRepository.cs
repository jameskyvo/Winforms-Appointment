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