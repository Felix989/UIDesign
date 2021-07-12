using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIDesign.User;

namespace UIDesign.dbController
{
    public static class dbController
    {

        public static SqlConnection connection = new SqlConnection();

        public static void connect()
        {
            string cn_String = Properties.Settings.Default.Connection_String;

            try
            {
                dbController.connection = new SqlConnection(cn_String);
                Console.WriteLine("Connection was successful!");
            }
            catch (Exception)
            {
                Console.WriteLine("Connection Error!");
                throw;
            }
        }

        public static bool login(UserDTO user)
        {
            try
            {
                dbController.connection.Open();
                string readString = "select * from [UserDTO]";
                using (SqlCommand command = new SqlCommand(readString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            String userName = reader["UserName"].ToString();
                            String passWord = reader["PassWord"].ToString();
                            if (user.UserName == userName && user.Password == passWord) {
                                return true;
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return false;
        }
    }
}

