using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using TeacherGradingUI_WF.DA_Layer;
using TeacherGradingUI_WF.Helper;
using TeacherGradingUI_WF.PD_Layer;

namespace TeacherGradingUI_WF.FormViews
{
    /// <summary>
    /// This is the Login form page that appers when the program is loaded.
    /// This is where the user inputs their username, password and role to login to their account and access their information.
    /// This page takes these inputs and displays one of the corresponding views relating to the role of the user.
    /// </summary>
    public partial class Login : Form
    {
        /// <summary>
        /// Built in function that initializes the login page when the program starts.
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }

        /// Combo box containing the roles of the potential users.
        private void cbLoginRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// Text box for the user to input their password.
        private void tbLoginPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        /// Text box for users to input thier email.
        private void tbLoginEmail_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This is an event handler that establishes a connection with the datatbase when the program is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Load(object sender, EventArgs e)
        {
            dbHelper.EstablishConnection();
        }

        /// <summary>
        /// This is an event handler that is called when the login button is clicked.
        /// It takes the text from the text boxes LoginEmail, LoginPassword, LoginRole.
        /// The user email and role is then used to find the user in database and compare it to the password inputed.
        /// This is then used to display the data in the view based on what account has logged in.
        /// The user ID is passed into the next form that is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btLogin_Click(object sender, EventArgs e)
        {
            // This takes the text from the text boxes and combo box and assigns it to string variables
            string email = LoginEmail.Text;
            string password = LoginPassword.Text;
            string role = (string)LoginRole.SelectedItem;

            /// The commented out code is just for testing, it is a list of pre-decided accounts to login into so I don't have to login every time.

            //string email = "sassam@hollyfield.kingston.sch.uk";
            //string password = "hollyfieldSA";
            //string role = "teacher";

            //string email = "jday@hollyfield.kingston.sch.uk";
            //string password = "hollyfield";
            //string role = "student";

            //string email = "Day001";
            //string password = "hollyfield";
            //string role = "parent";

            // This function retrieves a user from the database using the values in the text boxes
            User aUser = UsersDA.RetrieveUser(email, role);
            if (aUser != null) // Checks a user was returned
            {
                if (aUser.Password.Equals(password)) // Checks the password is correct
                {
                    switch (role) // Opens the correct view depending on the type of account and passes in the id of the user
                    {
                        case ("teacher"):
                            FormViews.TeacherView T = new FormViews.TeacherView();
                            T.UserID = aUser.id; //Passes in User ID (does the same for all views)
                            T.ShowDialog();
                            break;
                        case ("parent"):
                            FormViews.ParentView P = new FormViews.ParentView();
                            P.UserID = aUser.id;
                            P.ShowDialog();
                            break;
                        case ("admin"):
                            FormViews.AdminView A = new FormViews.AdminView();
                            A.UserID = aUser.id;
                            A.ShowDialog();
                            break;
                        case ("student"):
                            FormViews.StudentView S = new FormViews.StudentView();
                            S.UserID = aUser.id;
                            S.ShowDialog();
                            break;
                        default:
                            MessageBox.Show("Please select a role");
                            break;
                    }
                }
                else // Error message
                {
                    MessageBox.Show("Incorrect password. Please try again");
                    LoginEmail.Text = "";
                    LoginPassword.Text = "";
                }
            }
            else // Error message
            {
                MessageBox.Show("User not found. Please try again");
                LoginEmail.Text = "";
                LoginPassword.Text = "";
            }
        }
    }
}
