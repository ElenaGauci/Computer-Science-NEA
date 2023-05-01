using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherGradingUI_WF
{
    /// <summary>
    /// This class contains a constuctor for Student and a override for when converting the class to string.
    /// </summary>
    internal class Student
    {
        public string idStudent;
        public string FirstName;
        public string Surname;
        public string TargetGrade;
        public string TestQuestion;

        /// <summary>
        /// This is a constructor that creates a instant of the Student with thier id, first and surname, target grade and string of test questions.
        /// It is called from TestDataDA after retriving the data from the database.
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="FirstName"></param>
        /// <param name="Surname"></param>
        /// <param name="TargetGrade"></param>
        /// <param name="TestQuestion"></param>
        public Student (string idStudent, string FirstName, string Surname, string TargetGrade, string TestQuestion)
        {
            this.idStudent = idStudent;
            this.FirstName = FirstName;
            this.Surname = Surname;
            this.TargetGrade = TargetGrade;
            this.TestQuestion = TestQuestion;
        }

        /// <summary>
        /// This overrideds the typical output of .ToString so it can be in the correct format to be put in a list box.
        /// It need to be in a format that makes the list box look like a table.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        { 
            string StudentString = String.Format(idStudent + "\t" + "\t" + FirstName + "\t" + "\t" + Surname + "\t" + "\t" + TargetGrade + "\t" + TestQuestion);
            return StudentString;
        }
    }
}
