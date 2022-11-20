using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODotNet
{
    public class AddressBook
    {
        public static string con = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TestDb; Integrated Security = SSPI";
        SqlConnection connection = new SqlConnection(con);
        //public string AddContact(Model model)
        //{
        //   // string con = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Userdata; Integrated Security = SSPI";
        //    SqlCommand com = new SqlCommand("AddUser",connection);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@Name",model.Name);
        //    com.Parameters.AddWithValue("@Email",model.Email);
        //    com.Parameters.AddWithValue("@Mobile", model.Mobile);
        //    com.Parameters.AddWithValue("@City", model.City);
        //    connection.Open();
        //    int i = com.ExecuteNonQuery();
        //    connection.Close();
        //    if (i != null)
        //    {
        //        return "data added";
        //        Console.WriteLine("data added");
        //    }
        //    else
        //    {
        //        return "data not added";
        //    }

        //}

        public List<Model> GetData()
        {
            List<Model> list = new List<Model>();
            SqlCommand com = new SqlCommand("getUser", connection);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            connection.Open();
            adapter.Fill(dt);
            connection.Close();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(
                    new Model
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Email = Convert.ToString(dr["Email"]),
                        Mobile = Convert.ToString(dr["Mobile"]),
                        City = Convert.ToString(dr["City"])
                    });
            }
            return list;
        }

        public bool Updateuser(Model mod)
        {
            Console.WriteLine("update user details");
            SqlCommand com = new SqlCommand("UpdateUser", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", mod.Id);
            com.Parameters.AddWithValue("@Name", mod.Name);
            com.Parameters.AddWithValue("@Email",mod.Email);
            com.Parameters.AddWithValue("Mobile", mod.Mobile);
            com.Parameters.AddWithValue("City", mod.City);
            connection.Open();
            var i= com.ExecuteNonQuery();
            connection.Close();
            if (i != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool DeleteUser(int Id)
        {
            Console.WriteLine("Delete user details");
            SqlCommand command = new SqlCommand("Deleteuser", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            connection.Open();
            var i = command.ExecuteNonQuery();
            connection.Close();
            if (i != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
