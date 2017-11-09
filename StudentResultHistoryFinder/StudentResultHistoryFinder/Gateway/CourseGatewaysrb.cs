using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StudentResultHistoryFinder.Models;

namespace StudentResultHistoryFinder.Gateway
{
    public class CourseGatewaysrb
    {
        List<Studentsinfosrb> studentsinfosrbs = new List<Studentsinfosrb>();
        string connectionString = WebConfigurationManager.ConnectionStrings["StudentsResultHistoryDBConnectionString"].ConnectionString;
        public List<Studentsinfosrb> GetStudent(int batch,int courseid)
        {
           
            SqlConnection connection=new SqlConnection(connectionString);
            string query = "SELECT * FROM EnrollCourse WHERE Batch='" + batch + "' AND courseid='" + courseid + "'";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Studentsinfosrb aStudentsinfosrb=new Studentsinfosrb();
                aStudentsinfosrb.EnrollCourseID = (int) reader["EnrollCourseID"];
                aStudentsinfosrb.CourseID = (int) reader["courseid"];
                aStudentsinfosrb.StudentId = Convert.ToInt32(reader["StudentId"]);
                studentsinfosrbs.Add(aStudentsinfosrb);
            }
           
            connection.Close();
            reader.Close();

            string query2 = "SELECT* FROM SelfStudyRegistration WHERE SelfStudyBatch='" + batch + "' AND courseid='" + courseid + "'";
            SqlCommand command2 = new SqlCommand(query2, connection);
            connection.Open();
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                Studentsinfosrb aStudentsinfosrb2 = new Studentsinfosrb();
             
                aStudentsinfosrb2.CourseID = (int)reader2["courseid"];
                aStudentsinfosrb2.StudentId = Convert.ToInt32(reader2["StudentId"]);
                studentsinfosrbs.Add(aStudentsinfosrb2);
            }
            reader2.Close();
            connection.Close();


            return studentsinfosrbs;
        }

        public List<Coursesrb> Getallcourse()
        {
            List<Coursesrb> courses=new List<Coursesrb>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT* FROM Course ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               Coursesrb course=new Coursesrb();
                course.courseid = (int) reader["CourseId"];
                course.coursecode = reader["CourseCode"].ToString();
                courses.Add(course);
            }
            reader.Close();
            connection.Close();
            return courses;
        }
    }
}