using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;
using TeacherGradingUI_WF.DA_Layer;
using TeacherGradingUI_WF.Helper;

namespace TeacherGradingUI_WF.FormViews
{
    /// <summary>
    /// This form is displayed when a student account has logged in.
    /// There are two combo boxes, one containing the classes the student takes and the other containing all of the tests that class has taken.
    /// There is a small list box at the top that contains all of the question marks for the test selected.
    /// The list box to the bottom left contains all of the tests for that class and the students total and grade.
    /// The text box in the middle is for the student to write notes like a to-do list and the notes will be saved to the their account in the table student
    /// when the save buton is pressed. The box is also cleared when the clear button is pressed and the notes that are saved in the table appear on load.
    /// The text box to the right contains hte teachers note from the specific test that has been selected and will load every time the test id is changed.
    /// </summary>
    public partial class StudentView : Form
    {
        // Passing in the ID for the student that has logged in
        public String UserID;

        /// <summary>
        /// This is a procedure that Updates the UI when the form is first loaded.
        /// In this case it adds the students classes to the first combo box, gives headers to the test table and retrieves students notes.
        /// It does this by querying the database and then adding the classes to a list to then adding them to the combo box one by one.
        /// </summary>
        private void UpdateUI()
        {
            string idTest = (string)cbTestS.SelectedItem;
            // Adding the student classes to the combo box
            cbClassS.Items.Clear();
            string query = "SELECT idClass FROM teachergrading.classenrolment where idStudent = (@id)";
            string idToBeFound = "idClass";
            List<string> ClassList = TestDataDA.RetrieveCBData(query, UserID, idToBeFound);
            foreach (string ClassItem in ClassList)
            {
                cbClassS.Items.Add(ClassItem);
            }

            // Adding heading to the tables
            listbTestS.Items.Clear();
            listbTestS.Items.Add("Test" + "\t" + "\t" + "Grade" + "\t" + "Total");
            listbTestS.Items.Add(" ");

            listbAllTest.Items.Clear();
            listbAllTest.Items.Add("Test" + "\t" + "\t" + "Grade" + "\t" + "Total");
            listbAllTest.Items.Add(" ");

            // Retrieving students personal notes
            string query2 = "SELECT Notes FROM teachergrading.student where idStudent = @id";
            string Notes = TestDataDA.RetrieveNotes(query2, UserID, idTest, "1");
            tbStudentNotes.Text = Notes;
        }

        /// <summary>
        /// Built in function that initializes the student view when the user has logged in.
        /// </summary>
        public StudentView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This updates the UI when the form is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentView_Load(object sender, EventArgs e)
        {
            UpdateUI(); // UI is updated on load
        }

        /// <summary>
        /// This code will when the combo box containing the list of classes changes.
        /// The code will fill the test combo box will all of the tests the selected class had taken.
        /// It does this by querying the database and then adding the tests to a list to then adding them to the combo box one by one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cbClassS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idclass = (string)cbClassS.SelectedItem;
            // Clearing potential duplicates and re-adding the title
            cbTestS.Items.Clear();
            listbAllTest.Items.Clear();
            listbAllTest.Items.Add("Test" + "\t" + "\t" + "Grade" + "\t" + "Total");
            listbAllTest.Items.Add(" ");
            // Retrieves all of the tests completed by the specific class
            string query = "SELECT idTest FROM teachergrading.classtest where idclass = (@id)";
            string idToBeFound = "idTest";
            List<string> TestList = TestDataDA.RetrieveCBData(query, idclass, idToBeFound);
            foreach (string TestItem in TestList)
            {
                // Adds the current test id into the combo box and then adds the test data into the list box that contains all of the tests
                cbTestS.Items.Add(TestItem);
                listbAllTest.Items.Add(TestDataDA.RetrieveTotalAndGrade(UserID, TestItem));
            }
        }

        /// <summary>
        /// This code is run when the test in the combo box is changed.
        /// It takes the test id combo box and the users student id and then displays the exact marks and teachers notes for that test.
        /// The test marks include the individual question marks  and target grade as well as the total and the grade.
        /// The teachers notes are displayed in the text box and the current test is displayed at the top.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTestS_SelectedIndexChanged(object sender, EventArgs e)
        { 
            // Inputs the test data into tables when a class and test have been selected
            string idTest = (string)cbTestS.SelectedItem; // Retrieve Test from combo box

            List<string> QuestionsList = TestDataDA.RetrieveTestQuestions(UserID, idTest); // Retrieve a list of questions and scores for user
            int NumOfQ = TestDataDA.RetrieveNumOfQuestions(idTest); // This finds the number of questions in a given test
            // Add the question numbers to the heading
            string Questions = null;
            for (int i = 1; i <= NumOfQ; i++)
            {
                Questions = Questions + "Q" + i + "\t";
            }

            listbTestS.Items.Clear();
            listbTestS.Items.Add("Test" + "\t" + "\t" + Questions + "Total" + "\t" + "Grade");
            // Add student marks into table
            string Marks = idTest + "\t";
            foreach (string Item in QuestionsList)
            {
                Marks = Marks + Item + "\t";
            }
            listbTestS.Items.Add(Marks);

            // Retrieves and displays the teachers notes for that test
            string query = "SELECT Notes FROM teachergrading.studenttest where idStudent = @id1 and idTest = @id2";
            string TeacherNotes = TestDataDA.RetrieveNotes(query, UserID, idTest, "2");
            tbTeacherNotes.Text = TeacherNotes;
        }

        /// <summary>
        /// This is the list box that hold all the data for the current test selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbCurrentTest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This is the list box that holds all of the test and thier totals and grades for the current class selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbAllTests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// When this button is clicked the student notes text box is cleared of text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClear_Click(object sender, EventArgs e)
        {
            tbStudentNotes.Clear();
        }

        /// <summary>
        /// When this button is clicked any text that is in the text box will save into the student table under the current users id in the notes column.
        /// It does this by querying the database and updating that column to now read the text inputed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSave_Click(object sender, EventArgs e)
        {
            string Notes = tbStudentNotes.Text;
            string query = "UPDATE student\r\nSET Notes = @id1\r\nWHERE idStudent = @id2";
            dbHelper.UpdateDatabase2(query, Notes, UserID);
        }

        /// <summary>
        /// This is the text box where student notes are inputed, edited and displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbStudentNotes_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This is the text box where teachers notes are dispalyed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbTeacherNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSelectedTest_Click(object sender, EventArgs e)
        {

        }
    }
}
