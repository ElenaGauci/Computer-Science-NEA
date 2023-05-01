using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeacherGradingUI_WF.DA_Layer;

namespace TeacherGradingUI_WF.FormViews
{
    /// <summary>
    /// This is the view that is displayed when a parent account has logged in.
    /// It contains combo boxes where the parent can change what child and which of their classes they want to view.
    /// There is a list box that contains all of the tests that class had taken and the current students total and grade.
    /// There is a text box that contains the teacher notes and test id for each test in the list box.
    /// </summary>
    public partial class ParentView : Form
    {
        // Passing in the ID for the parent that has logged in
        public String UserID; 

        /// <summary>
        /// This is a procedure that Updates the UI when the form is first loaded.
        /// In this case it adds the parents children to the first combo box and gives headers to the test table.
        /// It does this by querying the database and then adding the names to a list to then adding them to the combo box one by one.
        /// </summary>
        private void UpdateUI()
        {
            // Adding the parent children to the combo box
            cbStudent.Items.Clear(); // So there are no duplicates
            string query = "SELECT idStudent FROM teachergrading.student where idParent = (@id)";
            string idToBeFound = "idStudent";
            List<string> NameList = TestDataDA.RetrieveCBData(query, UserID, idToBeFound);
            foreach (string Name in NameList)
            {
                cbStudent.Items.Add(Name);
            }
            // Creating headings
            lbTests.Items.Clear();
            lbTests.Items.Add("Test" + "\t" + "\t" + "Grade" + "\t" + "Total");
            lbTests.Items.Add(" ");
        }

        /// <summary>
        /// Built in function that initializes the parent view when the user has logged in.
        /// </summary>
        public ParentView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This updates the UI when the form is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParentView_Load(object sender, EventArgs e)
        {
            UpdateUI(); // UI is updated on load
        }

        /// <summary>
        /// This code will when the combo box containing the list of students the parent is responible for changes.
        /// The code will fill the class combo box will all of the classes the selected student takes.
        /// It does this by querying the database and then adding the names to a list to then adding them to the combo box one by one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idStudent = (string)cbStudent.SelectedItem;
            cbClass.Items.Clear(); // So there are no duplicates
            string query = "SELECT idClass FROM teachergrading.classenrolment where idStudent = @id"; // Query
            string idToBeFound = "idClass"; // ID
            List<string> ClassList = TestDataDA.RetrieveCBData(query, idStudent, idToBeFound);
            foreach (string ClassItem in ClassList)
            {
                cbClass.Items.Add(ClassItem);
            }
        }

        /// <summary>
        /// This code is run when the class in the combo box is changed.
        /// It takes the class id and the student id from the combo boxes and then display the data of all the tests the student has done in the list box.
        /// It also displays all of the teachers notes written to the student and the corresponding test id in the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieving and instantiating the class id, student id and the notes variable
            string idClass = (string)cbClass.SelectedItem;
            string idStudent = (string)cbStudent.SelectedItem;
            string Notes = null;
            // Clearing potential duplicates and re-adding the title
            lbTests.Items.Clear();
            lbTests.Items.Add("Test" + "\t" + "\t" + "Grade" + "\t" + "Total");
            lbTests.Items.Add(" ");
            // Retrieves all of the tests completed by the specific student in the specific class
            string query = "SELECT idTest FROM teachergrading.classtest where idclass = (@id)";
            string idToBeFound = "idTest";
            List<string> TestList = TestDataDA.RetrieveCBData(query, idClass, idToBeFound);
            foreach (string TestItem in TestList)
            {
                // Adds the current test data into the list box and then retrieves the notes and test id for that test and inputs it into the text box
                lbTests.Items.Add(TestDataDA.RetrieveTotalAndGrade(idStudent, TestItem));
                string query2 = "SELECT Notes FROM teachergrading.studenttest where idStudent = @id1 and idTest = @id2";
                string TeacherNotes = TestDataDA.RetrieveNotes(query2, idStudent, TestItem, "2");
                Notes = Notes + TestItem + "\t" + TeacherNotes + "\r\n" + "\r\n";
            }
            tbNotes.Text = Notes;
        }

        /// List box containing all of the test data for the student and class selected.
        private void lbTests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// Text box displaying all of the teacher notes from the tests that are being displayed in the list box.
        private void tbNotes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
