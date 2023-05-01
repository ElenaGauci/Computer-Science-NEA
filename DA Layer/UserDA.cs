using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeacherGradingUI_WF.Helper;
using TeacherGradingUI_WF.PD_Layer;

namespace TeacherGradingUI_WF.DA_Layer
{
    /// <summary>
    /// This class contains all of the functions relating to login in a user so the right information can be displayed.
    /// It is responsible for filling combo boxes with the correct data, adding data to lists boxes from tests and adding the notes to text boxes from the database.
    /// </summary>
    public static class UsersDA
    {
        // This is a static MySQLCommand object that is used through out the functions instead of instantiating it every time
        private static MySqlCommand cmd = null;
        // This is a DataTable object that is filled everytime data is retrived from the database
        private static DataTable dt;
        // This acts as a bridge between the SQL data and the C# code
        private static MySqlDataAdapter sda;
        public static string uID = null;

        /// <summary>
        /// This function takes the result of a MySLQCommand and puts the data into a C# table so the data can be processed.
        /// This function is called everytime data is retrived from the database.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private static DataTable TableData(MySqlCommand cmd)
        {
            dt = new DataTable();
            sda = new MySqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }

        /// <summary>
        /// This function has an email/username and role passed in from the login view text box and combo box.
        /// It then finds the user (if there is one) in the database and then return a class containing the email and pasword of the user so it can be comapred.
        /// It is call from the login view.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public static User RetrieveUser(string email, string role) 
        {
            User aUser = null;
            string query = null;
            string id = null;
            // SQL workbench wouldn't accept a (@) insert for the table so I wrote a switch stament to choose the table based on the role
            switch (role) 
            {
                case ("teacher"):
                    query = "SELECT * FROM teachergrading.teacher where Email = (@id) limit 1";
                    id = "idTeacher";
                    break;
                case ("parent"):
                    query = "SELECT * FROM teachergrading.parent where Email = (@id) limit 1";
                    id = "idParent";
                    break;
                case ("admin"):
                    query = "SELECT * FROM teachergrading.admin where Email = (@id) limit 1";
                    id = "idAdmin";
                    break;
                case ("student"):
                    query = "SELECT * FROM teachergrading.student where Email = (@id) limit 1";
                    id = "idStudent";
                    break;
                default:
                    MessageBox.Show("Table not found");
                    break;
            }
            if (role != null)
            {
                cmd = dbHelper.RetrieveData1(query, email); // Fuction to return data based on the query inputed
                if (cmd != null) // Checking a command was returned
                {
                    dt = TableData(cmd); // Makes C# table with SQL data
                    foreach (DataRow dr in dt.Rows) // Loops through the table (in this case only once)
                    {
                        string uEmail = dr["email"].ToString();
                        string uPassword = dr["password"].ToString();
                        uID = dr[id].ToString();
                        aUser = new User(uEmail, uPassword, uID); // Creates a user to be returned to login page
                    }
                }
            }
            return aUser;
        }
    }
}