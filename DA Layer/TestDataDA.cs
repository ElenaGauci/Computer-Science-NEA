using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeacherGradingUI_WF.FormViews;
using TeacherGradingUI_WF.Helper;
using TeacherGradingUI_WF.PD_Layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TeacherGradingUI_WF.DA_Layer
{
    /// <summary>
    /// This class contains all of the functions relating to retrieving and displaying data from the database in forms.
    /// It is responsible for filling combo boxes with the correct data, adding data to lists boxes from tests and adding the notes to text boxes from the database.
    /// </summary>
    internal class TestDataDA
    {
        // This is a static MySQLCommand object that is used through out the functions instead of instantiating it every time
        private static MySqlCommand cmd = null;
        // This is a DataTable object that is filled everytime data is retrived from the database
        private static DataTable dt;
        // This acts as a bridge between the SQL data and the C# code
        private static MySqlDataAdapter sda;

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
        /// This function retrives a certain id (idToBeFound) from a query and inputs the ids one by one into the combo box.
        /// This function is called every time a combo box needs to be filled with situation dependent data.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="id"></param>
        /// <param name="idToBeFound"></param>
        /// <returns></returns>
        public static List<string> RetrieveCBData(string query, string id, string idToBeFound)
        {
            try
            {
                cmd = dbHelper.RetrieveData1(query, id); // Fuction to return data based on the query inputed
            }
            catch
            {
                MessageBox.Show("Opps, something went wrong when retriving combo box data");
            }

            List<string> DataList = new List<string>(); // Defined DataList

            if (cmd != null) // Checking a command was returned
            {
                dt = TableData(cmd); // Makes C# table with SQL data
                foreach (DataRow dr in dt.Rows) // Loops through the table
                {
                    string CurrentItem = dr[idToBeFound].ToString();
                    DataList.Add(CurrentItem);
                }
            }
            return DataList;
        }

        /// <summary>
        /// This function has a query, two ids and the deired result passed in.
        /// This function is used to retrieve and output the notes held in the table student and studenttest.
        /// There are two potential results as both the student id and the test id are needed when finding the correct row in studetntest but only the
        /// student id is needed when retriving from student. Instead of writing two functions I decided to write two potential results depending on the
        /// amount ids that need to be passed in.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="CurrentID"></param>
        /// <param name="idTest"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string RetrieveNotes(string query, string CurrentID, string idTest, string result)
        {
            string Notes = null;
            if (result == "1")
            {
                cmd = dbHelper.RetrieveData1(query, CurrentID);
            }
            else if (result == "2")
            {
                cmd = dbHelper.RetrieveData2(query, CurrentID, idTest);
            }
            dt = TableData(cmd);
            foreach (DataRow dr in dt.Rows)
            {
                Notes = dr["Notes"].ToString();
            }
            return Notes;
        }

        /// <summary>
        /// This function is used in the student and parent view for the simplified test view and without the individual test marks.
        /// It passes in the student id and the test id so the grades and totals acn be found in the studenttest table.
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idTest"></param>
        /// <returns></returns>
        public static string RetrieveTotalAndGrade(string idStudent, string idTest)
        {
            string query = "SELECT Total, Grade FROM teachergrading.studenttest where idStudent = @id1 and idTest = @id2";
            cmd = dbHelper.RetrieveData2(query, idStudent, idTest); 
            string Test = null;

            if (cmd != null) // Checking a command was returned
            {
                dt = TableData(cmd); // Makes C# table with SQL data
                foreach (DataRow dr in dt.Rows) // Loops through the table
                {
                    string Total = dr["Total"].ToString();
                    string Grade = dr["Grade"].ToString();
                    Test = idTest + "\t" + Grade + "\t" + Total;
                }
            }
            return Test;
        }

        /// <summary>
        /// This function retrieves student id, name, target grade, marks for test questions, total mark and grade for every student in the class and test selected.
        /// Then it takes all of these values for a single student and adds them to a class. Then the new instance of the class is added to a list.
        /// This is because a 2d array can't be used due to the fact that their length has to be predetermined and the data has varing length. 
        /// Also 2d list are not very effiecent or simple to read/change. Also with each student being a class the .ToString could be overrid alot easier
        /// mean there is more control over how the string is displayed in the list box.
        /// It is called when filling the ClassTestTable list box in teacher view.
        /// It takes in the idClass and idTest that are selected in the combo boxes and outputs a list of class objects.
        /// </summary>
        /// <param name="idClass"></param>
        /// <param name="idTest"></param>
        /// <returns></returns>
        public static List<Student> RetrieveTeachersStudentList(string idClass, string idTest) // Retrives data to inputed into tables
        {
            try
            {
                string query = "SELECT idStudent, TargetGrade FROM teachergrading.classenrolment where idClass = (@id)";
                cmd = dbHelper.RetrieveData1(query, idClass);
            }
            catch
            {
                MessageBox.Show("Opps, something went wrong when retriving table data");
            }

            List<Student> StudentsList = new List<Student>();
            //This function outputs a list of classes that are then turned to string to be inputed to the listboxes (tables) in the main program
            if (cmd != null)
            {
                dt = TableData(cmd);
                foreach (DataRow dr in dt.Rows)
                {
                    // The student id and target grade of the current student are found from classenrolment and then assinged to variables
                    Student CurrentStudent;
                    string idStudent = dr["idStudent"].ToString();
                    string TargetGrade = dr["TargetGrade"].ToString();
                    string query2 = "SELECT FirstName, Surname FROM teachergrading.student where idStudent = (@id)";
                    cmd = dbHelper.RetrieveData1(query2, idStudent); // Then that student id is used to find their name
                    dt = TableData(cmd);
                    foreach (DataRow dr2 in dt.Rows)
                    {
                        string FirstName = dr2["FirstName"].ToString(); // Their first and surname are assigned to variables
                        string Surname = dr2["Surname"].ToString();
                        string TestQuestion = null;
                        List<string> TQ = RetrieveTestQuestions(idStudent, idTest); // This fuction finds the students test scores for students                             
                        foreach (string Question in TQ)                                // and returns them in a string
                        {
                            TestQuestion = TestQuestion + Question + "\t";
                        }
                        CurrentStudent = new Student(idStudent, FirstName, Surname, TargetGrade, TestQuestion); // ID, name, target grade and test question scores                
                        StudentsList.Add(CurrentStudent);                         //are added to CurrentStudent and then added to the StudentList as a new student
                    }
                }
            }
            return StudentsList;
        }

        /// <summary>
        /// This function retieves the individual test marks, test total and grade for the student and test id passed in.
        /// It first cycles through all of the test question in the test and selects the mark that relates to the current test question and student.
        /// Then the value is added to the total and then coverted to a string and added to a list. 
        /// After the program has cycled through all of the test questions it works out the grade with the total and adds the total and grade to the string.
        /// It is called during RetrieveTeachersStudentList (multiple times as their are multiple students), on the parent view and the student view.
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idTest"></param>
        /// <returns></returns>
        public static List<string> RetrieveTestQuestions(string idStudent, string idTest)
        {
            List<string> TestQuestions = new List<string>();

            int Total = 0;
            string query = "SELECT idTestQuestion FROM teachergrading.testquestion WHERE idTest = (@id)";
            cmd = dbHelper.RetrieveData1(query, idTest);
            dt = TableData(cmd);
            // Loops through all of the testquestions where the test id matches the current test
            foreach (DataRow dr in dt.Rows)
            {
                string idTestQuestion = dr["idTestQuestion"].ToString();
                // Then finds the mark from questionanswer where the question and student id match
                string query2 = "SELECT Mark FROM teachergrading.questionanswer WHERE idTestQuestion = (@id1) AND idStudent = (@id2)";
                cmd = dbHelper.RetrieveData2(query2, idTestQuestion, idStudent);
                dt = TableData(cmd);
                // It the adds the mark to a list as a string and also adds up all of the marks to create a total mark
                foreach (DataRow dr2 in dt.Rows)
                {
                    string MarkString = dr2["Mark"].ToString();
                    int Mark = Convert.ToInt32(dr2["Mark"]);
                    Total = Total + Mark;
                    TestQuestions.Add(MarkString);
                }
            }
            // Works out the grade
            string grade = Grade(Total, idTest); 
            string StringTotal = Convert.ToString(Total);
            // Adds the total and grade to the end of the list
            TestQuestions.Add(StringTotal);
            TestQuestions.Add(grade);
            // Adds the total and grade to the database
            string query3 = "UPDATE studenttest\r\nSET Total = @id1, Grade= @id2\r\nWHERE idStudent = @id3 AND idTest = @id4;";
            dbHelper.UpdateDatabase4(query3, Total, grade, idStudent, idTest);
            return TestQuestions;
        }

        /// <summary>
        /// This function works out the grade for a test.
        /// It works by taking the total that the student scored and the test id and divides the students total mark by the total mark that can be scored 
        /// for that test. Then it is multiplied by 100 to get a percentage. Then there is an if statement to work out what grade bracket the mark falls in.
        /// </summary>
        /// <param name="Total"></param>
        /// <param name="idTest"></param>
        /// <returns></returns>
        public static string Grade(int Total, string idTest)
        {
            string grade = null;
            string query = "SELECT TotalMark FROM teachergrading.test WHERE idTest = (@id)";
            cmd = dbHelper.RetrieveData1(query, idTest);
            dt = TableData(cmd);
            double TotalMark = 0;
            foreach (DataRow dr in dt.Rows)
            {
                TotalMark = Convert.ToInt32(dr["TotalMark"]);
            }
            double percentage = ((Total / TotalMark) * 100);
            if (100 >= percentage && percentage >= 90)
            {
                grade = "A*";
            }
            else if (90 > percentage && percentage >= 80)
            {
                grade = "A";
            }
            else if (80 > percentage && percentage >= 70)
            {
                grade = "B";
            }
            else if (70 > percentage && percentage >= 60)
            {
                grade = "C";
            }
            else if (60 > percentage && percentage >= 50)
            {
                grade = "D";
            }
            else if (50 > percentage && percentage >= 40)
            {
                grade = "E";
            }
            else if (40 > percentage && percentage >= 0)
            {
                grade = "U";
            }
            return grade;
        }

        /// <summary>
        /// This function finds the number of questions in a test.
        /// The test id is passed and it outputs a interger.
        /// This called mainly when question headings need to be made in tables.
        /// </summary>
        /// <param name="idTest"></param>
        /// <returns></returns>
        public static int RetrieveNumOfQuestions(string idTest)
        {
            int NumOfQuestions = 0;
            string query = "SELECT idTestQuestion FROM teachergrading.testquestion where idTest = (@id)";
            cmd = dbHelper.RetrieveData1(query, idTest);
            dt = TableData(cmd);
            foreach (DataRow dr in dt.Rows)
            {
                NumOfQuestions = NumOfQuestions + 1;
            }
            return NumOfQuestions;
        }
    }
}
