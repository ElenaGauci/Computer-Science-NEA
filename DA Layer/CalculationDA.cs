using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeacherGradingUI_WF.Helper;
using TeacherGradingUI_WF.PD_Layer;

namespace TeacherGradingUI_WF.DA_Layer
{
    /// <summary>
    /// This is a class that contains all of the functions related to math calucuations.
    /// This includes and is mainly limited to calcuating the averages of the test scores and grades.
    /// </summary>
    internal class CalculationDA
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
        /// This function is used to calculate the average test mark for each question, total and grade across the class selected. 
        /// It works by first looping through all of the test questions and finding the desired statistic for each and putting them into a string.
        /// Then a list of totals, grades and target grades are found. When the average of these are calculated the target grade is put at the beginning
        /// of the string and the total and grade are put at the end of the string.
        /// Grades are assigned a number in place of a letter when calculating the average and the translated back.
        /// It is called every time the Averages combo box has a change in index.
        /// </summary>
        /// <param name="idTest"></param>
        /// <param name="SelectedStatType"></param>
        /// <param name="idClass"></param>
        /// <returns></returns>
        public static List<string> CalcAverages(string idTest, string SelectedStatType, string idClass)
        {
            string query = "SELECT idTestQuestion FROM teachergrading.testquestion where idTest = (@id)";
            cmd = dbHelper.RetrieveData1(query, idTest);

            List<string> AverageMarks = new List<string>();

            // Loops through all of the questions in a single test, computing statstics
            dt = TableData(cmd);
            foreach (DataRow dr in dt.Rows)
            {
                // For each question it collects all of the marks in a list and then finds the average
                List<int> Marks = new List<int>();
                string idTestQuestion = dr["idTestQuestion"].ToString();
                string query2 = "SELECT Mark FROM teachergrading.questionanswer where idTestQuestion = (@id)";
                cmd = dbHelper.RetrieveData1(query2, idTestQuestion);
                dt = TableData(cmd);
                foreach (DataRow dr2 in dt.Rows)
                {
                    int Mark = Convert.ToInt32(dr2["Mark"]);
                    Marks.Add(Mark);
                }

                // Switch statement to select which statistic should be calculated based on the input parameter SelectedStatType
                switch (SelectedStatType) 
                {
                    case ("Median"):
                        string QuestionStringMedian = Median(Marks);
                        AverageMarks.Add(QuestionStringMedian);
                        break;
                    case ("Mean"):
                        string QuestionStringMean = Mean(Marks);
                        AverageMarks.Add(QuestionStringMean);
                        break;
                    case ("Mode"):
                        string QuestionStringMode = Mode(Marks);
                        AverageMarks.Add(QuestionStringMode);
                        break;
                    default:
                        MessageBox.Show("Opps something when wrong with the calculating Averages");
                        break;
                }
            }

            /// This sesction loops through all rows and produces a list of totals and grades for each student.
            /// The lists are then passed to the selected stat function
            
            List<int> Totals = new List<int>();
            List<int> Grades = new List<int>();
            List<int> TargetGrades = new List<int>();
            string query3 = "SELECT Total, Grade FROM teachergrading.studenttest where idTest = (@id)";
            cmd = dbHelper.RetrieveData1(query3, idTest);
            dt = TableData(cmd);
            foreach (DataRow dr3 in dt.Rows)
            {
                int Total = Convert.ToInt32(dr3["Total"]);
                string Grade = dr3["Grade"].ToString();
                int intGrade = GradeToNumber(Grade);
                Totals.Add(Total);
                Grades.Add(intGrade);
            }
            string query4 = "SELECT TargetGrade FROM teachergrading.classenrolment where idClass = (@id)";
            cmd = dbHelper.RetrieveData1(query4, idClass);
            dt = TableData(cmd);
            foreach (DataRow dr4 in dt.Rows)
            {
                string TargetGrade = dr4["TargetGrade"].ToString();
                int intTargetGrade = GradeToNumber(TargetGrade);
                TargetGrades.Add(intTargetGrade);
            }

            /// Switch statement to select which statistic should be calculated based on the input parameter SelectedStatType.
            switch (SelectedStatType) 
            {
                case ("Median"):
                    string TotalsStringMedian = Median(Totals);
                    string GradesStringMedian = Median(Grades);
                    string TargetGradesStringMedian = Median(TargetGrades);
                    string stringGradeMedian = NumberToGrade(GradesStringMedian);
                    string stringTargetGradeMedian = NumberToGrade(TargetGradesStringMedian);
                    AverageMarks.Add(TotalsStringMedian);
                    AverageMarks.Add(stringGradeMedian);
                    AverageMarks.Insert(0, stringTargetGradeMedian);
                    break;
                case ("Mean"):
                    string TotalsStringMean = Mean(Totals);
                    string GradesStringMean = Mean(Grades);
                    string TargetGradesStringMean = Mean(TargetGrades);
                    string stringGradeMean = NumberToGrade(GradesStringMean);
                    string stringTargetGradeMean = NumberToGrade(TargetGradesStringMean);
                    AverageMarks.Add(TotalsStringMean);
                    AverageMarks.Add(stringGradeMean);
                    AverageMarks.Insert(0, stringTargetGradeMean);
                    break;
                case ("Mode"):
                    string TotalsStringMode = Mode(Totals);
                    string GradesStringMode = Mode(Grades);
                    string TargetGradesStringMode = Mode(TargetGrades);
                    string stringGradeMode = NumberToGrade(GradesStringMode);
                    string stringTargetGradeMode = NumberToGrade(TargetGradesStringMode);
                    AverageMarks.Add(TotalsStringMode);
                    AverageMarks.Add(stringGradeMode);
                    AverageMarks.Insert(0, stringTargetGradeMode);
                    break;
                default:
                    MessageBox.Show("Opps something when wrong with the calculating Averages");
                    break;
            }
            return AverageMarks;
        }

        /// <summary>
        /// Converts a grade string to an integer number.
        /// These numbers are used simply to compute an average grade number.
        /// </summary>
        /// <param name="Grade"></param>
        /// <returns></returns>
        private static int GradeToNumber(string Grade)
        {
            int intGrade = 0;
            switch (Grade)
            {
                case ("A*"):
                    intGrade = 6;
                    break;
                case ("A"):
                    intGrade = 5;
                    break;
                case ("B"):
                    intGrade = 4;
                    break;
                case ("C"):
                    intGrade = 3;
                    break;
                case ("D"):
                    intGrade = 2;
                    break;
                case ("E"):
                    intGrade = 1;
                    break;
                case ("U"):
                    intGrade = 0;
                    break;
            }
            return intGrade;
        }

        /// <summary>
        /// Converts a number string to an grade string.
        /// The number is computed from the average of all the grade numbers and the converted back into the string grade.
        /// </summary>
        /// <param name="intGrade"></param>
        /// <returns></returns>
        private static string NumberToGrade(string intGrade)
        {
            string stringGrade = null;
            switch (intGrade)
            {
                case ("6"):
                    stringGrade = "A*";
                    break;
                case ("5"):
                    stringGrade = "A";
                    break;
                case ("4"):
                    stringGrade = "B";
                    break;
                case ("3"):
                    stringGrade = "C";
                    break;
                case ("2"):
                    stringGrade = "D";
                    break;
                case ("1"):
                    stringGrade = "E";
                    break;
                case ("0"):
                    stringGrade = "U";
                    break;
            }
            return stringGrade;
        }

        /// <summary>
        /// Calculated the median of a list of numbers that are passed in (most of the time it would be a list of student marks or grades)
        /// It sorts the list from lowest to highest value and then find the middle of the list, by using functions.
        /// It is called several times through out the CalcAverages function in order to find the median score of the question, total or grade needed.
        /// Converted into string at the end so it can be inputed into a list box.
        /// Private as it is a local function.
        /// </summary>
        /// <param name="List"></param>
        /// <returns></returns>
        private static string Median(List<int> List)
        {
            Int32 length = List.Count;
            List<int> ListSorted = SortList(List, 0, length - 1);
            string Median = (Middle(ListSorted, length)).ToString();
            return Median;
        }

        /// <summary>
        /// Calculates the mean of a list of numbers that are passed in (most of the time it would be a list of student marks or grades)
        /// It adds all of the values in the list and then divides that total by the number of items in the list.
        /// Converted into string at the end so it can be inputed into a list box.
        /// Private as it is a local function.
        /// </summary>
        /// <param name="List"></param>
        /// <returns></returns>
        private static string Mean(List<int> List)
        {
            int Total = 0;
            int Mean = 0;
            foreach (int Item in List)
            {
                Total = Total + Item;
            }
            if (List.Count > 0)
            {
                Mean = Total / List.Count;
            }
            string MeanString = Mean.ToString();
            return MeanString;
        }

        /// <summary>
        /// Calculates the mode of a list of numbers that are passed in (most of the time it would be a list of student marks or grades)
        /// It sort the list first using a merge sort function and then every time a value is the same a the previous one then Count counts up by one.
        /// If the value changes the the count resets and if the count excceds the last largest count then that value becomes the new mode.
        /// If there is more than one mode then the functon will pick the lowest modal value.
        /// Converted into string at the end so it can be inputed into a list box.
        /// Private as it is a local function.
        /// </summary>
        /// <param name="List"></param>
        /// <returns></returns>
        private static string Mode(List<int> List)
        {
            int Count = 0;
            int LargestCount = 0;
            Int32 length = List.Count;
            List<int> ListSorted = SortList(List, 0, length - 1);
            int ModeInt = 0;
            for (int i = 0; i < length - 1; i++)
            {
                if (ListSorted[i] == ListSorted[i + 1])
                {
                    Count = Count + 1;
                    if (Count > LargestCount)
                    {
                        ModeInt = ListSorted[i];
                    }
                }
                else if (ListSorted[i] != ListSorted[i + 1])
                {
                    Count = 0;
                }
            }
            string Mode = ModeInt.ToString();
            return Mode;
        }

        /// <summary>
        /// This function finds the middle of a list.
        /// It is called when finding the median.
        /// It works by finding the length. If the it is even then it will find the mean of 
        /// two middle values and if the it is odd then middle value is selected.
        /// Private as it is a local function.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static int Middle(List<int> list, int length)
        {
            int middle = 0;
            if (list.Count > 1)
            {
                if (length % 2 == 0)
                {
                    int mid = length / 2;
                    middle = (list[mid] + list[mid + 1]) / 2;
                }
                else if (length % 2 == 1)
                {
                    int mid = (length - 1) / 2;
                    middle = list[mid + 1];
                }
                else
                {
                    MessageBox.Show("Opps something went wrong with finding the middle");
                }
            }
            return middle;
        }

        /// <summary>
        /// This is a recursive function that merge sorts a list that is passed in. 
        /// The paremeter passed in are a list, the index of the left most value and the index of the right most value.
        /// The algorithm splits the list into smaller lists and then sorts the smallest list and merges them back with the other sorted lists.
        /// It is called when calculating median and mode and it also calls itself.
        /// Private as it is a local function.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static List<int> SortList(List<int> list, int left, int right) // Uses a recursive algroithm to merge sort a list
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                SortList(list, middle, left);
                SortList(list, middle + 1, right);
                list = MergeList(list, left, middle, right);
            }
            return list;
        }

        /// <summary>
        /// This is a function that is linked to the SortList function.
        /// Its sorts the small lists (two item long normally) by puting value one into a tempory location, moving the value two to the right location and
        /// the adding value one to the space where value two was. Then the list is merged with other sorted lists until the stack has unreaveled.
        /// Private as it is a local function.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="left"></param>
        /// <param name="middle"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static List<int> MergeList(List<int> list, int left, int middle, int right) // Merges all the seperated lists back into one
        {
            var leftListLength = middle - left + 1;
            var rightListLength = right - middle;
            var leftTempList = new int[leftListLength];
            var rightTempList = new int[rightListLength];
            int i, j;

            for (i = 0; i < leftListLength; i++)
                leftTempList[i] = list[left + i];
            for (j = 0; j < rightListLength; j++)
                rightTempList[j] = list[middle + 1 + j];
            i = 0;
            j = 0;
            int k = left;

            while (i < leftListLength && j < rightListLength)
            {
                if (leftTempList[i] <= rightTempList[j])
                {
                    list[k++] = leftTempList[i++];
                }
                else
                {
                    list[k++] = rightTempList[j++];
                }
            }

            while (i < leftListLength)
            {
                list[k++] = leftTempList[i++];
            }
            while (j < rightListLength)
            {
                list[k++] = rightTempList[j++];
            }
            return list;
        }
    }
}