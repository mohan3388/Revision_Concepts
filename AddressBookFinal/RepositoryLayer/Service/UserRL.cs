using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL:IUserRL
    {
        private readonly string ConnectionString;
        public UserRL(IConfiguration configuration)
        {

            ConnectionString = configuration.GetConnectionString("TestDb");
        }
        public RegisterModel userRegistration(RegisterModel userRegister)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand command = new SqlCommand("SpUserRegister", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", userRegister.FirstName);
                command.Parameters.AddWithValue("@LastName", userRegister.LastName);
                command.Parameters.AddWithValue("@Email", userRegister.Email);
                command.Parameters.AddWithValue("@Password",userRegister.Password);
                connection.Open();
                var result = command.ExecuteNonQuery();
                connection.Close();
                if (result != null)
                {
                    return userRegister;
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
        public string UserLogin(LoginModel userLogin)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                string Password = "";
                long Id = 0;
                SqlCommand cmd = new SqlCommand("SpUserselect", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", userLogin.Email);
                sqlConnection.Open();
                var result = cmd.ExecuteNonQuery();
                // sqlConnection.Close();
                SqlDataReader Dr = cmd.ExecuteReader();
                while (Dr.Read())
                {
                    string Name = Convert.ToString(Dr["FirstName"]);
                    string Email = Convert.ToString(Dr["Email"]);
                    Id = Convert.ToInt32(Dr["Id"]);
                    Password = Convert.ToString(Dr["Password"]);


                }
                sqlConnection.Close();
                var pass = Password;
                // var email = userLogin.Email;
                if (pass == userLogin.Password)
                {

                    return GenerateJWTToken(userLogin.Email, Id);
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
        private string GenerateJWTToken(string email, long Id)
        {
            try
            {
                // generate token
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("ThisismySecretKey");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("Email", email),

                    new Claim("Id", Id.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),

                    SigningCredentials =
                    new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature),
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
