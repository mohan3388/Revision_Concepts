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
                command.Parameters.AddWithValue("@Password", Encrypt_Password(userRegister.Password));
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
                    string FirstName = Convert.ToString(Dr["FirstName"]);
                    string Email = Convert.ToString(Dr["Email"]);
                    Id = Convert.ToInt32(Dr["Id"]);
                    Password = Convert.ToString(Dr["Password"]);


                }
                sqlConnection.Close();
                var pass = Decrypt_Password(Password);
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
        public string ForgetPassword(string Email)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                long Id = 0;
                SqlCommand cmd = new SqlCommand("SpForgetPassword", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                connection.Open();
                var result = cmd.ExecuteNonQuery();
                SqlDataReader sqlData = cmd.ExecuteReader();
                ForgetPasswordModel forgetPass = new ForgetPasswordModel();
                // UserRegisterModel userRegisterModels = new UserRegisterModel();
                if (sqlData.Read())
                {
                    forgetPass.Id = sqlData.GetInt32("Id");
                    forgetPass.Email = sqlData.GetString("Email");
                    forgetPass.FirstName = sqlData.GetString("FirstName");
                    forgetPass.LastName = sqlData.GetString("LastName");
                }
                if (forgetPass.Email != null)
                {
                    MSMQModel mSMQModel = new MSMQModel();
                    var token = GenerateJWTToken(Email, Id);
                    mSMQModel.sendData2Queue(token);
                    return token.ToString();
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
        public bool ResetPassword(string Email, ResetPasswordModel resetModel)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("ResetPassword", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (resetModel.Password == resetModel.ConfirmPassword)
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Password", Encrypt_Password(resetModel.Password));
                }
                connection.Open();
                var result = cmd.ExecuteNonQuery();
                connection.Close();
                if (result != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private string Decrypt_Password(string encryptpassword)
        {
            string pswstr = string.Empty;
            System.Text.UTF8Encoding encode_psw = new System.Text.UTF8Encoding();
            System.Text.Decoder Decode = encode_psw.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpassword);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            pswstr = new String(decoded_char);
            return pswstr;
        }
        private string Encrypt_Password(string password)
        {
            string pswstr = string.Empty;
            byte[] psw_encode = new byte[password.Length];
            psw_encode = System.Text.Encoding.UTF8.GetBytes(password);
            pswstr = Convert.ToBase64String(psw_encode);
            return pswstr;
        }
    }
}
