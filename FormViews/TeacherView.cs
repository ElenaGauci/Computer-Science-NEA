using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TeacherGradingUI_WF.DA_Layer;
using TeacherGradingUI_WF.Helper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace TeacherGradingUI_WF.FormViews
{
    /// <summary>
    /// This form is displayed when a teacher account logs in.
    /// There are two combo boxes, one contains all of the classes the teacher teaches and the other contains the selected classes tests.
    /// The main list box at the top contains all of the students in the selected class and each of their marks for the test selected.
    /// Small list box underneath contains the average marks across all of the questions, totals and grades. 
    /// The type of average statitstic is selected in the combo box to the side of the list box.
    /// The text box at the bottom is where teachers can leave notes on their students tests. Once the test is selected the student ids of the students in 
    /// the class appear in the combo box next to the text box. When the save button is pressed the text in the text box is saved to the notes colunm in 
    /// studenttest where the student id and test id match what is currently selected in the combo boxes.
    /// The clear button remove all text from the text box.
    /// The load button loads the text from the notes colunm in studenttest where the student id and test id match what is currently selected in the combo boxes.
    /// </summary>
    public partial class TeacherView : Form
    {
        // Passing in the ID for the teacher that has logged in
        public String UserID;

        /// <summary>
        /// This is a procedure that Updates the UI when the form is first loaded.
        /// In this case it adds the teachers classes to the first combo box, gives headers to the test and averages table.
        /// It does this by querying the database and then adding the classes to a list to then adding them to the combo box one by one.
        /// </summary>
        public void UpdateUI()
        {
            // Adding the teachers classes to the combo box
            cbClass.Items.Clear(); // So there are no duplicates
            string query = "SELECT idClass FROM teachergrading.class where idTeacher = (@id)"; // Query
            string idToBeFound = "idClass"; // ID
            List<string> ClassList = TestDataDA.RetrieveCBData(query, UserID, idToBeFound);
            foreach (string ClassItem in ClassList)
            {
                cbClass.Items.Add(ClassItem);
            }

            // Adding heading to the tables
            ClassTestTable.Items.Clear();
            ClassTestTable.Items.Add("ID" + "\t" + "\t" + "FirstName" + "\t" + "\t" + "Surname" + "\t" + "\t" + "TG" + "\t" + "Total" + "\t" + "Grade");
            ClassTestTable.Items.Add(" ");

            listbAverages.Items.Clear();
            listbAverages.Items.Add("TG" + "\t" + "Total" + "\t" + "Grade");
            listbAverages.Items.Add(" ");
        }

        /// <summary>
        /// Built in function that initializes the login page when the program starts.
        /// </summary>
        public TeacherView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This updates the UI when the form is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeacherView_Load(object sender, EventArgs e)
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
        public void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idClass = (string)cbClass.SelectedItem;
            // This add tests to the test combo box depending on what class has been selected
            cbTest.Items.Clear(); // So there are no duplicates
            string query = "SELECT idTest FROM teachergrading.classtest where idClass = (@id)"; // Query
            string idToBeFound = "idTest"; // ID
            List<string> TestList = TestDataDA.RetrieveCBData(query, idClass, idToBeFound);
            foreach (string TestItem in TestList)
            {
                cbTest.Items.Add(TestItem);
            }
            cbStudent.Items.Clear();
            query = "SELECT idStudent FROM teachergrading.classenrolment where idClass = (@id)"; // Query
            idToBeFound = "idStudent"; // ID
            List<string> Students = TestDataDA.RetrieveCBData(query, idClass, idToBeFound);
            foreach (string Student in Students)
            {
                cbStudent.Items.Add(Student);
            }
        }

        /// <summary>
        /// This code is run when the test in the combo box is changed.
        /// It finds all of the students in a selected class and addeds then to a combo box that can be used to write notes on those students tests.
        /// It also creates a list of those students and their test scores, grades and target grades. 
        /// It then displays the headers for the test questions in both the test table and th averages table and then it displays all of the data for that 
        /// particular test and class in the test table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTest_SelectedIndexChanged(object sender, EventArgs e) 
        {
            string idClass = (string)cbClass.SelectedItem; // Retrieve Class from combo box
            string idTest = (string)cbTest.SelectedItem; // Retrieve Test from combo box

            // Retrieve a list of students from that class with test scores and number of questions in the test
            List<Student> StudentList = TestDataDA.RetrieveTeachersStudentList(idClass, idTest); 
            int NumOfQ = TestDataDA.RetrieveNumOfQuestions(idTest); 
            // Add the question numbers to the heading
            string Questions = null;
            for (int i = 1; i <= NumOfQ; i++) 
            {
                Questions = Questions + "Q" + i + "\t";
            }
            // Clear potential duplicates and re-add headings
            ClassTestTable.Items.Clear();
            ClassTestTable.Items.Add("ID" + "\t" + "\t" + "FirstName" + "\t" + "\t" + "Surname" + "\t" + "\t" + "TG" + "\t" + Questions + "Total" + "\t" + "Grade");
            ClassTestTable.Items.Add(" ");
            // Add Students and their test scores to the list box in the right format
            foreach (Student Item in StudentList) 
            {
                string CurrentItem = Item.ToString();
                ClassTestTable.Items.Add(CurrentItem);
            }

            // Retrieve number of questions in the test
            int NumOfQ2 = TestDataDA.RetrieveNumOfQuestions(idTest); 
            // Add the question numbers to the heading
            string Questions2 = null;
            for (int i = 1; i <= NumOfQ2; i++)
            {
                Questions2 = Questions2 + "Q" + i + "\t";
            }
            // Clear potential duplicates and re-add headings
            listbAverages.Items.Clear();
            listbAverages.Items.Add("TG" + "\t" + Questions2 + "Total"+ "\t" + "Grade");
            listbAverages.Items.Add(" ");
        }

        /// <summary>
        /// This is a list box that is structured like a table and displays the list of names, ids, test scores and grades of the students in the class selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbClassTestTable_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This list box acts like a table and displays the average marks and grades of the student in the test box above and the type of statistic is 
        /// determined by what is selected in the combo box to the side of it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbAverages_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// This is the combo box that will change what type of average is being calculated in the list box to the side.
        /// This is called when the combo box state is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAverages_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idClass = (string)cbClass.SelectedItem;
            string idTest = (string)cbTest.SelectedItem;
            string SelectedStatType = (string)cbAverages.SelectedItem;

            // Retrieve number of questions in the test
            int NumOfQ2 = TestDataDA.RetrieveNumOfQuestions(idTest);
            // Add the question numbers to the heading
            string Questions2 = null;
            for (int i = 1; i <= NumOfQ2; i++)
            {
                Questions2 = Questions2 + "Q" + i + "\t";
            }
            listbAverages.Items.Clear();
            listbAverages.Items.Add("TG" + "\t" + Questions2 + "Total" + "\t" + "Grade");
            listbAverages.Items.Add(" ");
            
            // Calculate the Average for each score and display it in the table 
            List<string> AverageMarks = CalculationDA.CalcAverages(idTest, SelectedStatType, idClass);
            string ItemString = null;
            foreach (string Item in AverageMarks)
            {
                string CurrentItem = Item.ToString();
                ItemString = ItemString + CurrentItem + "\t";
            }
            listbAverages.Items.Add(ItemString);
        }

        /// <summary>
        /// This is a combo box that contains the student in the class. 
        /// When the index is changed it will display the teachers notes from that students test.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idStudent = (string)cbStudent.SelectedItem;
            string idTest = (string)cbTest.SelectedItem;
            string query = "SELECT Notes FROM teachergrading.studenttest where idStudent = @id1 and idTest = @id2";
            string TeacherNotes = TestDataDA.RetrieveNotes(query, idStudent, idTest, "2");
            tbTeacherNotes.Text = TeacherNotes;
        }

        /// <summary>
        /// This is a text box where the teachers notes for the current student and test is displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbTeacherNotes_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// When this button is clicked any text that is in the text box will save into the studenttest table under the current student and test id
        /// in the notes column.
        /// It does this by querying the database and updating that column to now read the text inputed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSave_Click(object sender, EventArgs e)
        {
            string idStudent = (string)cbStudent.SelectedItem;
            string idTest = (string)cbTest.SelectedItem;
            string Notes = tbTeacherNotes.Text;
            string query = "UPDATE studenttest\r\nSET Notes = @id1\r\nWHERE idStudent = @id2 and idTest = @id3";
            dbHelper.UpdateDatabase3(query, Notes, idStudent, idTest);
        }

        /// <summary>
        /// This button loads the notes from studenttest into the teacher notes list box where the student and test id match the ones selected in the combo boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btLoad_Click(object sender, EventArgs e)
        {
            string idStudent = (string)cbStudent.SelectedItem;
            string idTest = (string)cbTest.SelectedItem;
            string query = "SELECT Notes FROM teachergrading.studenttest where idStudent = @id1 and idTest = @id2";
            string TeacherNotes = TestDataDA.RetrieveNotes(query, idStudent, idTest, "2");
            tbTeacherNotes.Text = TeacherNotes;
        }

        /// <summary>
        /// When this button is clicked the teacher notes text box is cleared of text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClear_Click(object sender, EventArgs e)
        {
            tbTeacherNotes.Clear();
        }
    }
}
