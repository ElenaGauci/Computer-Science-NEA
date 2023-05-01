using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherGradingUI_WF.PD_Layer
{
    /// <summary>
    /// This class contains the constructors and the getters and setters for everything to do with users.
    /// It is call mainly from the login page.
    /// </summary>
    public class User
    {
        // Several private string so the data contained is more secure
        private string email;
        private string password;
        private string role;
        public string id;
        
        /// <summary>
        /// This is a constructor that creates a instant of the user with email and password so the user object can be used to login to the database.
        /// It is called from UserDA after retriving the data from the database.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="id"></param>
        public User(string email, string password, string id)
        {
            this.email = email;
            this.password = password;
            this.id = id;
        }

        /// <summary>
        /// This is a constructor that creates a instant of the user with just the id.
        /// It is called just before opening the form the user is logging into so the user id acn be passed in to be user at a later point.
        /// </summary>
        /// <param name="id"></param>
        public User(string id)
        {
            this.id = id;
        }

        /// <summary>
        /// Gets the email from the user class.
        /// </summary>
        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Gets the password from the user class.
        /// This is called when the password of the user is compared to the on that has been inputed into the text box.
        /// </summary>
        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Gets the role from the user class.
        /// </summary>
        public String Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}
