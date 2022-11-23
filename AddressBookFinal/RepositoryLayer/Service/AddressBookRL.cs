using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class AddressBookRL : IAddressBookRL
    {
        private readonly string ConnectionString;
        public AddressBookRL(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("TestDb");
        }
        public AddressBookModel CreateAddressBook(AddressBookModel model)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand command = new SqlCommand("SpAddressBook", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("@LastName", model.LastName);
                command.Parameters.AddWithValue("@Email", model.Email);
                command.Parameters.AddWithValue("@Mobile", model.Mobile);
                command.Parameters.AddWithValue("@Address", model.Address);
                command.Parameters.AddWithValue("@City", model.City);
                command.Parameters.AddWithValue("@State", model.State);
                command.Parameters.AddWithValue("@Pincode", model.Pincode);
                connection.Open();
                var result = command.ExecuteNonQuery();
                connection.Close();
                if (result != null)
                {
                    return model;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<GetAddressBookModel> GetAddressBook()
        {
            List<GetAddressBookModel> result = new List<GetAddressBookModel>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            try {
                connection.Open();
                SqlCommand com = new SqlCommand("SpgetAddressBook", connection);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    GetAddressBookModel model = new GetAddressBookModel();
                    model.Id = reader.GetInt32("Id");
                    model.FirstName = reader.GetString("FirstName");
                    model.LastName = reader.GetString("LastName");
                    model.Email = reader.GetString("Email");
                    model.Mobile = reader.GetString("Mobile");
                    model.Address = reader.GetString("Address");
                    model.City = reader.GetString("City");
                    model.State = reader.GetString("State");
                    model.Pincode = reader.GetString("Pincode");
                    result.Add(model);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
    }
    }
}