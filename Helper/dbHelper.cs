using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TeacherGradingUI_WF.Helper
{

    /// <summary>
    /// This class encapsulates the interfaces and queries to the SQL database.
    /// It is responsible for connecting to the database and forming commands to query data from the tables.
    /// This class is static as it is not meant to be instantiated.
    /// </summary>
    public static class dbHelper
    {
        // Single instance of the sql connection
        private static MySqlConnection connection;

        // This is a static MySQLCommand object that is used through out the functions instead of instantiating it every time
        private static MySqlCommand cmd = null;

        /// <summary>
        /// This function performs the initial opening and connection to the database.
        /// The DB is assumed to be local in this application.
        /// </summary>
        public static void EstablishConnection()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "127.0.0.1";           //This is hard-coded so the user doesn't have to login to the
                builder.UserID = "root";                //database themselves and can just login to their account.
                builder.Password = "TurnTh3FrogsG@y!";  //This add an extra layer of security to the database as users don't
                builder.Database = "teachergrading";    //need to know the passwords to login.
                builder.SslMode = MySqlSslMode.Disabled;
                connection = new MySqlConnection(builder.ToString());
                MessageBox.Show("Database connection successfull", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("connection Failed");
            }
        }

        /// <summary>
        /// Takes a query and edits the database.
        /// It does not return anything as it is only meant to Update data or Insert new data.
        /// This function in particular allows 4 unknowns to be passed into the query.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="id3"></param>
        /// <param name="id4"></param>
        public static void UpdateDatabase4(string query, int id1, string id2, string id3, string id4)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@id1", id1);
                    cmd.Parameters.AddWithValue("@id2", id2);
                    cmd.Parameters.AddWithValue("@id3", id3);
                    cmd.Parameters.AddWithValue("@id4", id4);
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception)
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Takes a query and edits the database.
        /// It does not return anything as it is only meant to Update data or Insert new data.
        /// This function in particular allows 3 unknowns to be passed into the query.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="id3"></param>
        public static void UpdateDatabase3(string query, string id1, string id2, string id3)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@id1", id1);
                    cmd.Parameters.AddWithValue("@id2", id2);
                    cmd.Parameters.AddWithValue("@id3", id3);
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception)
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Takes a query and edits the database.
        /// It does not return anything as it is only meant to Update data or Insert new data.
        /// This function in particular allows 2 unknowns to be passed into the query.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        public static void UpdateDatabase2(string query, string id1, string id2)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@id1", id1);
                    cmd.Parameters.AddWithValue("@id2", id2);
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception)
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Takes a query and Retrives data the database.
        /// This function retutrns the data at the end of the function so it can then 
        /// be processed in a C# table after it the function has returned a value.
        /// This function in particular allows 2 unknowns to be passed into the query.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static MySqlCommand RetrieveData2(string query, string id1, string id2)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@id1", id1);
                    cmd.Parameters.AddWithValue("@id2", id2);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception)
            {
                connection.Close();
            }
            return cmd;
        }

        /// <summary>
        /// Takes a query and Retrives data the database.
        /// This function retutrns the data at the end of the function so it can then 
        /// be processed in a C# table after it the function has returned a value.
        /// This function in particular allows 1 unknowns to be passed into the query.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MySqlCommand RetrieveData1(string query, string id)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception)
            {
                connection.Close();
            }
            return cmd;
        }
    }
}
