using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Gateway
{
    public class CourseGateway:Gateway
    {
        public int NewCourseSave(Course aCourse)
        {


            Query = "INSERT INTO Course VALUES (@code, @name, @credit)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = aCourse.CourseCode;
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aCourse.CourseName;
            Command.Parameters.Add("credit", SqlDbType.VarChar);
            Command.Parameters["credit"].Value = aCourse.CourseCredit;
          
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }


        public bool IsCourseCodeExists(Course aCourse)
        {

            Query = "SELECT * FROM Course WHERE CourseCode = '" + aCourse.CourseCode + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool isExist = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return isExist;




        }



        public bool IsCourseNameExists(Course aCourse)
        {

            Query = "SELECT * FROM Course WHERE CourseName = '" + aCourse.CourseName + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool isExist = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return isExist;




        }

        public List<Course> GetAllCourses()
        {
            Query = "SELECT * FROM Course";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Course> courses = new List<Course>();

            while (Reader.Read())
            {
                Course aCourse = new Course();

                aCourse.CourseId = (int)Reader["CourseId"];
                aCourse.CourseCode = Reader["CourseCode"].ToString();
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.CourseCredit = Convert.ToDouble(Reader["CourseCredit"]);
                

                courses.Add(aCourse);
            }

            Reader.Close();
            Connection.Close();

            return courses;
        }
    }



    }
